using System.Collections.Generic;

namespace IT.Valor.Common.Models
{
    public class PaginatedResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public bool HasPrevious { get; set; }

        public bool HasNext { get; set; }
    }
}
