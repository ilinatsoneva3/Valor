using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            this._userService = userService;
        }
    }
}
