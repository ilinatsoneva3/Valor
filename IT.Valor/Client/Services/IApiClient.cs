using System.Threading.Tasks;
using IT.Valor.Common.Models;
using IT.Valor.Common.Models.Quote;

namespace IT.Valor.Client.Services
{
    public interface IApiClient
    {
        Task<QuoteStatsDto> GetStatsAsync();

        Task<QuoteDto> PostQuoteAsync(CreateQuoteDto request);

        Task<PaginatedResult<QuoteDto>> GetForUserAsync(PageParameters parameters);
    }
}
