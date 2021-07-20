using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT.Valor.Common.Models.Index;

namespace IT.Valor.Client.Services
{
    public interface IApiClient
    {
        Task<QuoteStatsDto> GetStatsAsync();
    }
}
