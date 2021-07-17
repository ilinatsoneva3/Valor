using AutoMapper;
using IT.Valor.Core.DataTransferObjects.Book;
using IT.Valor.Core.Models;

namespace IT.Valor.Core.Mappings
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookDto>();
        }
    }
}
