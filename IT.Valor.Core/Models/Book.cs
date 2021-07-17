using System;
using System.Collections.Generic;
using System.Linq;
using IT.Valor.Core.Interfaces.Entities;

namespace IT.Valor.Core.Models
{
    public class Book : BaseEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime? PublishedOn { get; set; }

        public Guid AuthorId { get; set; }

        public Author Author { get; set; }

        public IEnumerable<Quote> Quotes { get; set; } = new HashSet<Quote>();

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
