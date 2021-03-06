using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using IT.Valor.Client.Services;
using IT.Valor.Common.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace IT.Valor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<IApiAuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<IClientUserService, ClientUserService>();
            builder.Services.AddScoped<IApiClient, ApiClient>();
            builder.Services.AddScoped<CurrentUser>();
            builder.Services.AddScoped<IGenericRepository, GenericRepository>();

            builder.Services.AddSingleton(
                new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
