using System.ComponentModel.DataAnnotations;

namespace IT.Valor.Common.Models.Index
{
    public class CreateQuoteDto
    {
        [Required]
        public string Content { get; set; }

        public string BookName { get; set; }

        [Required]
        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }
    }
}
