using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IT.Valor.Core.Common;
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
        private readonly IQuoteRepository _quoteRepository;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public QuoteService(IQuoteRepository quoteRepository,
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

            var author = await GetAuthorAsync(request);
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

        public async Task<PaginatedResult<QuoteDto>> GetAllForUserAsync(PageParameters parameters)
        {
            var currentUser = await _userService.GetCurrentUserAsync();

            var quotes = await _quoteRepository.GetForUserWithRealtedAsync(currentUser.Id, parameters.SearchTerm);

            return MapToDto(quotes, parameters);
        }

        public async Task<QuoteStatsOverviewDto> GetStatsAsync()
        {
            var currentUser = await _userService.GetCurrentUserAsync();

            var allQuotes = await _quoteRepository.GetAllWithRelatedAsync();
            var userQuotes = allQuotes.Where(q => q.AddedById == currentUser.Id);

            var rand = new Random();

            return new QuoteStatsOverviewDto
            {
                TotalQuotes = allQuotes.Count(),
                UserQuotes = userQuotes.Count(),
                RandomQuote = _mapper.Map<QuoteDto>(allQuotes.OrderBy(x => rand.NextDouble()).First()),
                UserRandomQuote = _mapper.Map<QuoteDto>(userQuotes?.OrderBy(x => rand.NextDouble()).First())
            };
        }

        public async Task<PaginatedResult<QuoteDto>> GetByAuthorNameAsync(PageParameters parameters)
        {
            var quotes = await _quoteRepository.FilterByAuthorNameAsync(parameters.SearchTerm);
            return MapToDto(quotes, parameters);
        }

        private async Task<AuthorDto> GetAuthorAsync(CreateQuoteDto request)
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

        private PaginatedResult<QuoteDto> MapToDto(IEnumerable<Quote> source, PageParameters parameters)
        {
            var quotesDto = source.Select(q => _mapper.Map<QuoteDto>(q));

            return PaginatedResult<QuoteDto>.ToPaginatedResult(quotesDto, parameters.PageNumber, parameters.PageSize);
        }
    }
}
