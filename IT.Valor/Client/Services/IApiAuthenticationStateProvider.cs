using System.Threading.Tasks;
using IT.Valor.Core.DataTransferObjects.UserAuthentication;

namespace IT.Valor.Client.Services
{
    public interface IApiAuthenticationStateProvider
    {
        Task AuthenticateUser(LoginInput loginResult);

        Task LogOutUser();
    }
}
