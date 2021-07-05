using System.Threading.Tasks;
using IT.Valor.Core.DataTransferObjects.UserAuthentication;
using IT.Valor.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT.Valor.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class UserAuthenticationController : ValorApiController
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        public UserAuthenticationController(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        [HttpPost("login")]
        public async Task<LoginResult> Login(UserCredentialsDto cred)
        {
            var result = await _userAuthenticationService.LoginUserAsync(cred);
            return result;
        }

        [HttpPost("register")]
        public async Task<LoginResult> Register(UserRegistrationDto registration)
        {
            var result = await _userAuthenticationService.RegisterUserAsync(registration);
            return result;
        }
    }
}
