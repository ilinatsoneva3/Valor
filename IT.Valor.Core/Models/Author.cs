using System;
using System.Collections.Generic;
using System.Linq;
using IT.Valor.Core.Interfaces.Entities;

namespace IT.Valor.Core.Models
{
    public class Author : BaseEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Pseudonym { get; set; }

        public DateTime? YearBorn { get; set; }

        public IEnumerable<Book> Books { get; set; } = new HashSet<Book>();

        public IEnumerable<Quote> Quotes { get; set; } = new HashSet<Quote>();

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
