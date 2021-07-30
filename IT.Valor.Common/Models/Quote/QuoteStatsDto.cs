namespace IT.Valor.Common.Models.Quote
{
    public class QuoteStatsDto
    {
        public int TotalQuotes { get; set; }

        public int UserQuotes { get; set; }

        public QuoteDto UserRandomQuote { get; set; } = new QuoteDto();

        public QuoteDto RandomQuote { get; set; } = new QuoteDto();
    }
}
