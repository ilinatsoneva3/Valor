using System;
using System.Threading.Tasks;
using AutoMapper;
using IT.Valor.Core.DataTransferObjects.Author;
using IT.Valor.Core.Interfaces.Repositories;
using IT.Valor.Core.Interfaces.Services;
using IT.Valor.Core.Models;

namespace IT.Valor.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IBaseRepository<Author> _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IBaseRepository<Author> authorRepository,
            IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> CreateWithFirstAndLastNameAsync(string firstName, string lastName)
        {
            EnsureAuthorHasNameProvided(firstName);

            var author = lastName switch
            {
                null => new Author
                {
                    Pseudonym = firstName
                },
                _ => new Author
                {
                    FirstName = firstName,
                    LastName = lastName
                }
            };

            _authorRepository.Add(author);
            await _authorRepository.SaveChangesAsync();

            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<AuthorDto> GetByFirstAndLastNameAsync(string firstName, string lastName)
        {
            EnsureAuthorHasNameProvided(firstName);

            var author = lastName switch
            {
                null => await _authorRepository.FirstOrDefaultAsync(a => a.Pseudonym == firstName),
                _ => await _authorRepository.FirstOrDefaultAsync(a => a.FirstName == firstName && a.LastName == lastName)
            };

            return _mapper.Map<AuthorDto>(author);
        }

        private void EnsureAuthorHasNameProvided(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required");
            }
        }
    }
}
