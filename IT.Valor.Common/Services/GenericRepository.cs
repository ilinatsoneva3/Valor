using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IT.Valor.Common.Helpers;

namespace IT.Valor.Common.Services
{
    public class GenericRepository : IGenericRepository
    {
        private readonly HttpClient _htppClient;
        private string _token = "";

        public GenericRepository(HttpClient httpClient)
        {
            _htppClient = httpClient;
        }

        public void SetToken(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                _token = token;
            }
        }

        public async Task<T> GetAsync<T>(string uri)
             => await CallAPI<T>(HttpMethod.Get, uri, null);

        public async Task<T> PostAsync<T>(string uri, T data)
            => await CallAPI<T>(HttpMethod.Post, uri, data);

        public async Task<TR> PostAsync<T, TR>(string uri, T data)
            => await CallAPI<TR>(HttpMethod.Post, uri, data);

        public async Task<T> PutAsync<T>(string uri, T data)
            => await CallAPI<T>(HttpMethod.Put, uri, data);

        public async Task DeleteAsync<T>(string uri)
            => await _htppClient.DeleteAsync(GetUri(uri));

        private string GetUri(string uri)
            => $"{uri}";

        private async Task<T> CallAPI<T>(HttpMethod method, string uri, object data)
        {
            var jsonResult = string.Empty;
            var req = new HttpRequestMessage(method, uri);
            req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (data is not null)
            {
                var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
                req.Content = content;
            }

            if (!string.IsNullOrEmpty(_token))
            {
                req.Headers.Add("Authorization", $"Bearer {_token}");
            }

            var response = await _htppClient.SendAsync(req);

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                jsonResult = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(jsonResult, options);
            }

            throw new CustomHttpException(response.StatusCode, jsonResult);
        }
    }
}
