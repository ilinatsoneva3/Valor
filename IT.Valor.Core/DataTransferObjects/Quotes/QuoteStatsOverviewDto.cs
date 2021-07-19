namespace IT.Valor.Core.DataTransferObjects.Quotes
{
    public class QuoteStatsOverviewDto
    {
        public int TotalQuotes { get; set; }

        public int UserQuotes { get; set; }

        public QuoteDto UserRandomQuote { get; set; }

        public QuoteDto RandomQuote { get; set; }
    }
}
