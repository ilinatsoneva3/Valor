using IT.Valor.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IT.Valor.Core.Interfaces.Repositories
{
    public interface IUserLikedQuoteRepository : IBaseRepository<UserLikedQuote>
    {
        Task<IEnumerable<UserLikedQuote>> GetByUserIdAsync(string userId);
    }
}
