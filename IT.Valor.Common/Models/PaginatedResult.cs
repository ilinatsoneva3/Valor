using System.Collections.Generic;

namespace IT.Valor.Common.Models
{
    public class PaginatedResult<T>
    {
        public List<T> Items { get; set; }

        public int TotalCount { get; set; }
    }
}
