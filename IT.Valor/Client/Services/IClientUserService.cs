using System;
using System.Threading.Tasks;
using IT.Valor.Common.Models;

namespace IT.Valor.Client
{
    public interface IClientUserService
    {
        event EventHandler<UserAuthenticatedArgs> UserAuthenticatedEvent;

        Task<UserDto> GetUserAsync(string id);
    }
}