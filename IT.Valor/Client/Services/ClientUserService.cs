using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IT.Valor.Client.Services;
using IT.Valor.Common.Models;
using IT.Valor.Common.Services;
using Microsoft.AspNetCore.Components.Authorization;
namespace IT.Valor.Client
{
    public class ClientUserService : IClientUserService
    {
        public event EventHandler<UserAuthenticatedArgs> UserAuthenticatedEvent;

        private readonly ICustomHttpClient _httpClient;
        private readonly AuthenticationStateProvider _authProvider;

        public ClientUserService(ICustomHttpClient httpClient,
            AuthenticationStateProvider authProvider)
        {
            _httpClient = httpClient;
            _authProvider = authProvider;
            _authProvider.AuthenticationStateChanged += AuthenticationStateChanged;
        }

        public async Task<UserDto> GetUserAsync(string id)
        {
            try
            {
                return await _httpClient.GetAsync<UserDto>($"api/users/{id}");
            }
            catch (Exception)
            {
                return new UserDto();
            }
        }

        public async Task<LoginInput> LoginUser(Credentials user)
        {
            try
            {
                var result = await _httpClient.PostAsync<Credentials, LoginInput>("api/auth/login", user);
                await ((IApiAuthenticationStateProvider)_authProvider).AuthenticateUser(result);
                return result;
            }
            catch (Exception)
            {
                await LogOutUser();
                return new LoginInput();
            }
        }

        public async Task LogOutUser()
        {
            await ((IApiAuthenticationStateProvider)_authProvider).LogOutUser();
        }

        public async Task<LoginInput> RegisterUser(UserRegistration user)
        {
            try
            {
                var result = await _httpClient.PostAsync<UserRegistration, LoginInput>("api/auth/register", user);
                await ((IApiAuthenticationStateProvider)_authProvider).AuthenticateUser(result);
                return result;
            }
            catch (Exception)
            {
                await LogOutUser();
                return new LoginInput();
            }
        }

        private void AuthenticationStateChanged(Task<AuthenticationState> task)
        {
            if (task.Result.User.Identity.IsAuthenticated)
            {
                var claimsIdentity = (ClaimsIdentity)task.Result.User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                UserAuthenticatedEvent?.Invoke(this, new UserAuthenticatedArgs(userId));
            }
            else
            {
                UserAuthenticatedEvent?.Invoke(this, new UserAuthenticatedArgs(""));
            }
        }
    }
}
