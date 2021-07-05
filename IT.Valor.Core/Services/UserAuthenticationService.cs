using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IT.Valor.Core.DataTransferObjects.UserAuthentication;
using IT.Valor.Core.Interfaces.Services;
using IT.Valor.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IT.Valor.Core.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserAuthenticationService(UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<LoginResult> LoginUserAsync(UserCredentialsDto credentials)
        {
            var user = await _userManager.FindByNameAsync(credentials.Username);

            if (user is not null)
            {
                var validCredentials = await _userManager.CheckPasswordAsync(user, credentials.Password);
                if (validCredentials)
                {
                    return GetLoginResult(user);
                }
            }

            return new LoginResult();
        }

        public async Task<LoginResult> RegisterUserAsync(UserRegistrationDto registration)
        {
            try
            {
                var userExists = await _userManager.FindByEmailAsync(registration.Email);

                if (userExists is not null)
                {
                    throw new ArgumentException("User with the same email already exists");
                }

                var newUser = new ApplicationUser
                {
                    FirstName = registration.FirstName,
                    LastName = registration.LastName,
                    Email = registration.Email
                };

                var result = await _userManager.CreateAsync(newUser);

                if (result.Succeeded)
                {
                    return GetLoginResult(newUser);
                }

                return new LoginResult();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private LoginResult GetLoginResult(ApplicationUser user)
        {
            var expirationDate = DateTime.UtcNow.AddDays(1);
            return new LoginResult
            {
                UserId = user.Id,
                ExpirationDate = expirationDate,
                Token = GenerateToken(user.Id, expirationDate)
            };
        }

        private string GenerateToken(string id, DateTime expirationDate)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, id)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var descriptor = new SecurityTokenDescriptor
                {
                    Audience = _configuration["Jwt:Audience"],
                    Issuer = _configuration["Jwt:Issuer"],
                    Subject = new ClaimsIdentity(claims),
                    Expires = expirationDate,
                    SigningCredentials = credentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(descriptor);

                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
