using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IT.Valor.Core.DataTransferObjects.User;
using IT.Valor.Core.Interfaces.Services;
using IT.Valor.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace IT.Valor.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserDto> GetByUserIdAsync(string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);

            if (user is null)
            {
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}
