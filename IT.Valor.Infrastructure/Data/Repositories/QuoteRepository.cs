using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT.Valor.Core.Helpers;
using IT.Valor.Core.Interfaces.Repositories;
using IT.Valor.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace IT.Valor.Infrastructure.Data.Repositories
{
    public class QuoteRepository : BaseRepository<Quote>, IQuoteRepository
    {
        public QuoteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Quote>> GetAllWithRelatedAsync()
            => await Context.Quotes
                .Include(q => q.Book)
                .Include(q => q.Author)
                .ToListAsync();

        public async Task<IEnumerable<Quote>> FilterByAuthorNameAsync(string searchTerm)
            => await Context.Quotes
                .Include(q => q.Book)
                .Include(q => q.Author)
                .FilterByAuthorName(searchTerm)
                .ToListAsync();

        public async Task<IEnumerable<Quote>> GetForUserWithRealtedAsync(string userId, string searchTerm)
            => await Context.Quotes
                .Include(q => q.Book)
                .Include(q => q.Author)
                .Where(q => q.AddedById == userId)
                .FilterByAuthorName(searchTerm)
                .OrderByDescending(q => q.DateCreated)
                .ToListAsync();
    }
}
