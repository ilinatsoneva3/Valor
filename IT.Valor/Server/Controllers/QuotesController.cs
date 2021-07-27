using System.Collections.Generic;
using System.Threading.Tasks;
using IT.Valor.Core.Common;
using IT.Valor.Core.DataTransferObjects.Quotes;
using IT.Valor.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<PaginatedResult<QuoteDto>> GetAllByUserAsync([FromQuery] PageParameters parameters)
        {
            var result = await _quoteService.GetAllForUserAsync(parameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.Metadata)); //TODO: check
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
