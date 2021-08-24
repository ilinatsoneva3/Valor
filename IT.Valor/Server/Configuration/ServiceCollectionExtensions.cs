using IT.Valor.Core.Interfaces.Repositories;
using IT.Valor.Core.Interfaces.Services;
using IT.Valor.Core.Models;
using IT.Valor.Core.Services;
using IT.Valor.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IT.Valor.Server.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IQuoteRepository, QuoteRepository>();
            services.AddScoped<IBaseRepository<Book>, BaseRepository<Book>>();
            services.AddScoped<IBaseRepository<Author>, BaseRepository<Author>>();
            services.AddScoped<IUserLikedQuoteRepository, UserLikedQuoteRepository>();
        }
    }
}
