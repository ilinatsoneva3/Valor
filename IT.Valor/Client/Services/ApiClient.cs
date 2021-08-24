using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IT.Valor.Common.Models;
using IT.Valor.Common.Models.Quote;
using IT.Valor.Common.Services;
using Microsoft.AspNetCore.WebUtilities;

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

        public async Task<PaginatedResult<QuoteDto>> GetForUserAsync(PageParameters parameters)
        {
            try
            {
                var queryStringParam = new Dictionary<string, string>
                {
                    ["pageNumber"] = parameters.PageNumber.ToString(),
                    ["searchTerm"] = parameters.SearchTerm == null ? string.Empty : parameters.SearchTerm
                };

                var uri = QueryHelpers.AddQueryString("api/quotes/all", queryStringParam);

                var result =  await _httpClient.GetAsync<PaginatedResult<QuoteDto>>($"{uri}");
                return result;
            }
            catch (Exception e)
            {

                return new PaginatedResult<QuoteDto>();
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
