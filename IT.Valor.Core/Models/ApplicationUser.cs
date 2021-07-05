using Microsoft.AspNetCore.Identity;

namespace IT.Valor.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
