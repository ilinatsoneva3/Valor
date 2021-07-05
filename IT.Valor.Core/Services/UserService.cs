using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT.Valor.Core.DataTransferObjects.User;
using IT.Valor.Core.Interfaces.Services;

namespace IT.Valor.Core.Services
{
    public class UserService : IUserService
    {
        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
