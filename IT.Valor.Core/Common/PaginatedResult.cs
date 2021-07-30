using System;
using System.Collections.Generic;
using System.Linq;

namespace IT.Valor.Core.Common
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(IEnumerable<T> items, int count)
        {
            Items = items;
            TotalCount = count;
        }

        public int TotalCount { get; set; }

        public IEnumerable<T> Items { get; set; }

        public static PaginatedResult<T> ToPaginatedResult<T>(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedResult<T>(items, count);
        }
    }
}
