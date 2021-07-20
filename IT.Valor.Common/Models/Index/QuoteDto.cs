using System;

namespace IT.Valor.Common.Models.Index
{
    public class QuoteDto
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public string BookTitle { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
