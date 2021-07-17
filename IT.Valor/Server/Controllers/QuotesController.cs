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

        [HttpPost]
        public async Task<QuoteDto> CreateQuoteAsync([FromBody] CreateQuoteDto request)
        {
            var result = await _quoteService.CreateQuoteAsync(request);

            return result;
        }
    }
}
