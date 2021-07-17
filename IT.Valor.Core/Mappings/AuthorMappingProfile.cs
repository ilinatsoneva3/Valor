using AutoMapper;
using IT.Valor.Core.DataTransferObjects.Author;
using IT.Valor.Core.Models;

namespace IT.Valor.Core.Mappings
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Author, AuthorDto>();
        }
    }
}
