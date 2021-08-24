using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace IT.Valor.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<Quote> Quotes { get; set; } = new HashSet<Quote>();

        public IEnumerable<UserLikedQuote> LikedQuotes { get; set; } = new HashSet<UserLikedQuote>();
    }
}
