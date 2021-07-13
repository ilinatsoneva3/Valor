using System.Threading.Tasks;
using IT.Valor.Core.DataTransferObjects.User;
using IT.Valor.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace IT.Valor.Server.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ValorApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<UserDto> GetUser([FromRoute] string id)
        {
            var result = await _userService.GetByUserIdAsync(id);
            return result;
        }

        [HttpGet("me")]
        public async Task<UserDto> GetUser()
        {
            var result = await _userService.GetCurrentUserAsync();
            return result;
        }
    }
}
