using System;
using IT.Valor.Core.Interfaces.Entities;

namespace IT.Valor.Core.Models
{
    public class Quote : BaseEntity
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public string AddedById { get; set; }

        public ApplicationUser AddedBy { get; set; }

        public Guid? BookId { get; set; }

        public Book Book { get; set; }

        public Guid? AuthorId { get; set; }

        public Author Author { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
