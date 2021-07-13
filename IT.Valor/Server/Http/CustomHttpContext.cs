using System.Linq;
using IT.Valor.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace IT.Valor.Server.Http
{
    public class CustomHttpContext : ICustomHttpContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomHttpContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId =>
            _httpContextAccessor.HttpContext.User.Claims?.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value;

        public bool IsAuthenticated =>
            _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
    }
}
