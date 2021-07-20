using System.Threading.Tasks;
using IT.Valor.Common.Models.Authentication;

namespace IT.Valor.Client.Services
{
    public interface IApiAuthenticationStateProvider
    {
        Task AuthenticateUser(LoginInput loginResult);

        Task LogOutUser();
    }
}
