using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using IT.Valor.Common.Helpers;
using IT.Valor.Common.Models;
using IT.Valor.Common.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace IT.Valor.Client.Services
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider, IApiAuthenticationStateProvider
    {
        private bool firstTime = true;

        private readonly ILocalStorageService _localStorageService;
        private readonly IGenericRepository _httpClient;

        public ApiAuthenticationStateProvider(ILocalStorageService localStorageService,
            IGenericRepository httpClient)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
        }

        public async Task AuthenticateUser(LoginInput loginResult)
        {
            var token = await ParseToken(loginResult);
            await AuthenticateUser(token);
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await GetTokenAsync();

            if (string.IsNullOrWhiteSpace(token.LoginResult.Token))
            {
                firstTime = false;
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            if (firstTime)
            {
                firstTime = false;
                await AuthenticateUser(token);
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(token.Claims, "jwt")));
        }

        public async Task LogOutUser()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));

            await _localStorageService.RemoveItemAsync("authToken");
            await _localStorageService.RemoveItemAsync("tokenExpire");

            _httpClient.SetToken(string.Empty);

            NotifyAuthenticationStateChanged(authState);
        }

        private async Task<SavedToken> GetTokenAsync()
        {
            var token = await _localStorageService.GetItemAsync<string>("authToken");
            var expDate = await _localStorageService.GetItemAsync<DateTime>("tokenExpire");
            return await ParseToken(new LoginInput
            {
                Token = token,
                ExpirationDate = expDate
            });
        }

        private async Task AuthenticateUser(SavedToken token)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, token.LoginResult.UserId) }, "apiauth"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

            await _localStorageService.SetItemAsync("authToken", token.LoginResult.Token);
            await _localStorageService.SetItemAsync("tokenExpire", token.LoginResult.ExpirationDate);

            _httpClient.SetToken(token.LoginResult.Token);

            NotifyAuthenticationStateChanged(authState);
        }

        private async Task<SavedToken> ParseToken(LoginInput loginInput)
        {
            if (string.IsNullOrEmpty(loginInput.Token))
            {
                return new SavedToken();
            }

            var isExpired = loginInput.ExpirationDate < DateTime.UtcNow;

            if (isExpired)
            {
                await LogOutUser();
                return new SavedToken();
            }

            var claims = JwtParserHelper.ParseClaimsFromJwt(loginInput.Token);
            var userId = claims.FirstOrDefault(x => x.Type == "nameid").Value;
            return new SavedToken
            {
                Claims = claims,
                LoginResult = new LoginInput
                {
                    UserId = userId,
                    ExpirationDate = loginInput.ExpirationDate,
                    Token = loginInput.Token
                }
            };
        }
    }
}
