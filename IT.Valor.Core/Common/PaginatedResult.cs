using System;
using System.Collections.Generic;
using System.Linq;

namespace IT.Valor.Core.Common
{
    public class PaginatedResult<T> : List<T>
    {
        public PaginatedResult(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            Metadata = new Metadata
            {
                TotalCount = count,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };

            AddRange(items);
        }

        public Metadata Metadata { get; set; }

        public static PaginatedResult<T> ToPaginatedResult<T>(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedResult<T>(items, count, pageNumber, pageSize);
        }
    }
}
