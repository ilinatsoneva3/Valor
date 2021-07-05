using IT.Valor.Core.Interfaces.Services;
using IT.Valor.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IT.Valor.Server.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
        }
    }
}
