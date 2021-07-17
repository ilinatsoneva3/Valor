using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IT.Valor.Core.DataTransferObjects.Author;
using IT.Valor.Core.DataTransferObjects.Book;
using IT.Valor.Core.Interfaces.Repositories;
using IT.Valor.Core.Interfaces.Services;
using IT.Valor.Core.Models;

namespace IT.Valor.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBaseRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBaseRepository<Book> bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> CreateBookByNameAsync(string name, AuthorDto author)
        {
            CheckIfAuthorIsNull(author);
            var book = new Book
            {
                Title = name,
                AuthorId = author.Id
            };

            _bookRepository.Add(book);
            await _bookRepository.SaveChangesAsync();

            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> GetBookByNameAsync(string name, AuthorDto author)
        {
            CheckIfAuthorIsNull(author);

            var book = await _bookRepository.FindAsync(b => b.Title == name && b.AuthorId == author.Id);
            return _mapper.Map<BookDto>(book);
        }

        private void CheckIfAuthorIsNull(AuthorDto author)
        {
            if (author is null)
            {
                throw new ArgumentException("Author must be provided");
            }
        }

    }
}
