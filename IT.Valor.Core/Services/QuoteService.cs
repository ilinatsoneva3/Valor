using System;
using System.Threading.Tasks;
using AutoMapper;
using IT.Valor.Core.DataTransferObjects.Author;
using IT.Valor.Core.DataTransferObjects.Book;
using IT.Valor.Core.DataTransferObjects.Quotes;
using IT.Valor.Core.Helpers;
using IT.Valor.Core.Interfaces.Repositories;
using IT.Valor.Core.Interfaces.Services;
using IT.Valor.Core.Models;

namespace IT.Valor.Core.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IBaseRepository<Quote> _quoteRepository;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public QuoteService(IBaseRepository<Quote> quoteRepository,
            IAuthorService authorService,
            IBookService bookService,
            IUserService userService,
            IMapper mapper)
        {
            _quoteRepository = quoteRepository;
            _authorService = authorService;
            _bookService = bookService;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<QuoteDto> CreateQuoteAsync(CreateQuoteDto request)
        {
            var currentUser = await _userService.GetCurrentUserAsync();

            if (currentUser is null)
            {
                throw new ArgumentException("User must be logged in");
            }

            var author = await GetAuthorIfExisting(request);
            var book = await GetBookAsync(request.BookName, author);

            var newQuote = new Quote
            {
                Content = request.Content,
                AddedById = currentUser.Id,
                BookId = book?.Id,
                AuthorId = author?.Id
            };

            _quoteRepository.Add(newQuote);

            await _quoteRepository.SaveChangesAsync();

            return _mapper.Map<QuoteDto>(newQuote);
        }

        private async Task<AuthorDto> GetAuthorIfExisting(CreateQuoteDto request)
        {
            var firstName = EnsureValidName(request.AuthorFirstName);
            var lastName = EnsureValidName(request.AuthorLastName);

            var author = await _authorService.GetByFirstAndLastNameAsync(firstName, lastName);

            return author switch
            {
                not null => author,
                _ => await _authorService.CreateWithFirstAndLastNameAsync(firstName, lastName)
            };
        }

        private async Task<BookDto> GetBookAsync(string name, AuthorDto author)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            var bookName = EnsureValidName(name);
            var book = await _bookService.GetBookByNameAsync(bookName, author);

            return book switch
            {
                not null => book,
                _ => await _bookService.CreateBookByNameAsync(name, author)
            };
        }

        private string EnsureValidName(string name)
        {
            if (name is null)
            {
                return null;
            }
            var trimmedName = name.Trim();
            return StringHelper.FirstLetterToUpper(trimmedName);
        }
    }
}
