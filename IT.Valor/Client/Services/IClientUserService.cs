using System;
using System.Threading.Tasks;
using IT.Valor.Common.Models.Authentication;

namespace IT.Valor.Client
{
    public interface IClientUserService
    {
        event EventHandler<UserAuthenticatedArgs> UserAuthenticatedEvent;

        Task<UserDto> GetUserAsync(string id);

        Task<LoginInput> LoginUser(Credentials user);

        Task LogOutUser();

        Task<LoginInput> RegisterUser(UserRegistration user);
    }
}