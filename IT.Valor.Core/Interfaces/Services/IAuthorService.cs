using System.Threading.Tasks;
using IT.Valor.Core.DataTransferObjects.Author;

namespace IT.Valor.Core.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<AuthorDto> GetByFirstAndLastNameAsync(string firstName, string lastName);

        Task<AuthorDto> CreateWithFirstAndLastNameAsync(string firstName, string lastName);
    }
}
