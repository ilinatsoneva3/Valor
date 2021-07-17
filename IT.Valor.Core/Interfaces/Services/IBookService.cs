using System.Threading.Tasks;
using IT.Valor.Core.DataTransferObjects.Author;
using IT.Valor.Core.DataTransferObjects.Book;

namespace IT.Valor.Core.Interfaces.Services
{
    public interface IBookService
    {
        Task<BookDto> CreateBookByNameAsync(string name, AuthorDto author);

        Task<BookDto> GetBookByNameAsync(string name, AuthorDto author);
    }
}
