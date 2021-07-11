using System.ComponentModel.DataAnnotations;

namespace IT.Valor.Common.Models
{
    public class Credentials
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
