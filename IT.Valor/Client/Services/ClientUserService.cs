using System;
using System.Security.Claims;
using System.Threading.Tasks;
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
    }
}
