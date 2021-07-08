using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT.Valor.Core.DataTransferObjects.User;

namespace IT.Valor.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> GetByUserIdAsync(string id);
    }
}
