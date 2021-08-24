using IT.Valor.Core.Interfaces.Repositories;
using IT.Valor.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT.Valor.Infrastructure.Data.Repositories
{
    public class UserLikedQuoteRepository : BaseRepository<UserLikedQuote>, IUserLikedQuoteRepository
    {
        public UserLikedQuoteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<UserLikedQuote>> GetByUserIdAsync(string userId)
            => await Context.UserLikedQuotes
                .Include(ulq => ulq.Quote)
                .Where(ulq => ulq.UserId == userId)
                .ToListAsync();
    }
}
