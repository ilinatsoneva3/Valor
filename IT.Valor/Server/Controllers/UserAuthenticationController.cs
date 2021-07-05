using System.Threading.Tasks;
using IT.Valor.Core.DataTransferObjects.UserAuthentication;
using IT.Valor.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT.Valor.Server.Controllers
{
    [Route("api/[controller]")]
    public class UserAuthenticationController : ValorApiController
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        public UserAuthenticationController(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<LoginResult> Login(UserCredentialsDto cred)
        {
            var result = await _userAuthenticationService.LoginUserAsync(cred);
            return result;
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<LoginResult> Register(UserRegistrationDto cred)
        {
            var result = await _userAuthenticationService.RegisterUserAsync(cred);
            return result;
        }
    }
}
