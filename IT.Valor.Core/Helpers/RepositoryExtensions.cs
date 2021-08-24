using IT.Valor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.Valor.Core.Helpers
{
    public static class RepositoryExtensions
    {
        public static IQueryable<Quote> FilterByAuthorName(this IQueryable<Quote> source, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return source;
            }

            return source.Where(q => q.Author.FirstName.ToLower().Contains(searchTerm) ||
                    q.Author.LastName.ToLower().Contains(searchTerm) ||
                    q.Author.Pseudonym.ToLower().Contains(searchTerm));
        }
    }
}
