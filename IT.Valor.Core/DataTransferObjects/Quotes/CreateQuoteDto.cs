namespace IT.Valor.Core.DataTransferObjects.Quotes
{
    public class CreateQuoteDto
    {
        public string Content { get; set; }

        public string BookName { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }
    }
}
