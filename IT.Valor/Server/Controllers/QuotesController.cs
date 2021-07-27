using System.Collections.Generic;
using System.Threading.Tasks;
using IT.Valor.Core.DataTransferObjects.Quotes;
using IT.Valor.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace IT.Valor.Server.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : ValorApiController
    {
        private readonly IQuoteService _quoteService;

        public QuotesController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet]
        public async Task<QuoteStatsOverviewDto> GetQuotesOverviewAsync()
        {
            var result = await _quoteService.GetStatsAsync();
            return result;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<QuoteDto>> GetAllByUserAsync()
        {
            var result = await _quoteService.GetAllForUserAsync();
            return result;
        }

        [HttpPost]
        public async Task<QuoteDto> CreateQuoteAsync([FromBody] CreateQuoteDto request)
        {
            var result = await _quoteService.CreateQuoteAsync(request);

            return result;
        }
    }
}
