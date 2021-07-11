using System.Threading.Tasks;

namespace IT.Valor.Common.Services
{
    public interface ICustomHttpClient
    {
        Task DeleteAsync<T>(string uri);

        Task<T> GetAsync<T>(string uri);

        Task<TR> PostAsync<T, TR>(string uri, T data);

        Task<T> PostAsync<T>(string uri, T data);

        Task<T> PutAsync<T>(string uri, T data);

        void SetToken(string token);
    }
}