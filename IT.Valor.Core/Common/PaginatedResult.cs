using System;
using System.Collections.Generic;
using System.Linq;

namespace IT.Valor.Core.Common
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(IEnumerable<T> items, int count, int totalPages, int currentPage)
        {
            Items = items;
            TotalCount = count;
            TotalPages = totalPages;
            CurrentPage = currentPage;
        }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }

        public int CurrentPage { get; set; }

        public bool HasPrevious => CurrentPage > 1;

        public bool HasNext => TotalPages > CurrentPage;

        public IEnumerable<T> Items { get; set; }

        public static PaginatedResult<T> ToPaginatedResult<T>(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return new PaginatedResult<T>(items, count, totalPages, pageNumber);
        }
    }
}
