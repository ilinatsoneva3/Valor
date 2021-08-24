using IT.Valor.Core.Interfaces.Entities;
using System;

namespace IT.Valor.Core.Models
{
    public class UserLikedQuote : BaseEntity
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public Guid QuoteId { get; set; }

        public Quote Quote { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
