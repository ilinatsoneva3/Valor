using System.ComponentModel.DataAnnotations;

namespace IT.Valor.Core.DataTransferObjects.UserAuthentication
{
    public class UserCredentialsDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
