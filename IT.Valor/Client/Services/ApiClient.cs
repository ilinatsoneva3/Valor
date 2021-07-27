using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT.Valor.Common.Models.Index;
using IT.Valor.Common.Services;

namespace IT.Valor.Client.Services
{
    public class ApiClient : IApiClient
    {
        private readonly IGenericRepository _httpClient;

        public ApiClient(IGenericRepository httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<QuoteStatsDto> GetStatsAsync()
        {
            try
            {
                return await _httpClient.GetAsync<QuoteStatsDto>($"api/quotes");
            }
            catch (Exception)
            {
                return new QuoteStatsDto();
            }
        }

        public async Task<IEnumerable<QuoteDto>> GetForUserAsync()
        {
            try
            {
                return await _httpClient.GetAsync<IEnumerable<QuoteDto>>($"api/quotes/all");
            }
            catch (Exception)
            {
                return Enumerable.Empty<QuoteDto>();
            }
        }

        public async Task<QuoteDto> PostQuoteAsync(CreateQuoteDto request)
        {
            try
            {
                return await _httpClient.PostAsync<CreateQuoteDto, QuoteDto>($"api/quotes", request);
            }
            catch (Exception)
            {

                return new QuoteDto();
            }
        }
    }
}
