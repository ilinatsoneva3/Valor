using System.Threading.Tasks;
using IT.Valor.Core.Common;
using IT.Valor.Core.DataTransferObjects.Quotes;

namespace IT.Valor.Core.Interfaces.Services
{
    public interface IQuoteService
    {
        Task<QuoteDto> CreateQuoteAsync(CreateQuoteDto request);

        Task<QuoteStatsOverviewDto> GetStatsAsync();

        Task<PaginatedResult<QuoteDto>> GetAllForUserAsync(PageParameters parameters);

        Task<PaginatedResult<QuoteDto>> GetByAuthorNameAsync(PageParameters parameters);
    }
}
