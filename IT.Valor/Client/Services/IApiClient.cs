using System.Collections.Generic;
using System.Threading.Tasks;
using IT.Valor.Common.Models.Index;

namespace IT.Valor.Client.Services
{
    public interface IApiClient
    {
        Task<QuoteStatsDto> GetStatsAsync();

        Task<QuoteDto> PostQuoteAsync(CreateQuoteDto request);

        Task<IEnumerable<QuoteDto>> GetForUserAsync();
    }
}
