using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT.Valor.Core.DataTransferObjects.UserAuthentication;
using IT.Valor.Core.Interfaces.Services;

namespace IT.Valor.Core.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        public Task<LoginResult> LoginUserAsync(UserCredentialsDto credentials)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResult> RegisterUserAsync(UserRegistrationDto credentials)
        {
            throw new NotImplementedException();
        }
    }
}
