using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using IT.Valor.Common.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace IT.Valor.Client.Services
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider, IApiAuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public ApiAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task AuthenticateUser(LoginInput loginResult)
        {
            var token = await GetTokenAsync();
        }

        private async Task<SavedToken> GetTokenAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task LogOutUser()
        {
            throw new NotImplementedException();
        }
    }
}
