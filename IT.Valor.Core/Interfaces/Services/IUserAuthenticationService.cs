using System.Threading.Tasks;
using IT.Valor.Core.DataTransferObjects.UserAuthentication;

namespace IT.Valor.Core.Interfaces.Services
{
    public interface IUserAuthenticationService
    {
        Task<LoginResult> LoginUserAsync(UserCredentialsDto credentials);

        Task<LoginResult> RegisterUserAsync(UserRegistrationDto credentials);
    }
}
