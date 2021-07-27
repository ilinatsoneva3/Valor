using System.Collections.Generic;
using System.Threading.Tasks;
using IT.Valor.Core.Models;

namespace IT.Valor.Core.Interfaces.Repositories
{
    public interface IQuoteRepository : IBaseRepository<Quote>
    {
        Task<IEnumerable<Quote>> GetAllWithRelatedAsync();

        Task<IEnumerable<Quote>> GetForUserWithRealtedAsync(string userId);
    }
}
