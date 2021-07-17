using AutoMapper;
using IT.Valor.Core.DataTransferObjects.Quotes;
using IT.Valor.Core.Models;

namespace IT.Valor.Core.Mappings
{
    public class QuoteMappingProfile : Profile
    {
        public QuoteMappingProfile()
        {
            CreateMap<Quote, QuoteDto>()
                .ForMember(dest => dest.AuthorName,
                    opt => opt.MapFrom(x => x.Author.FirstName != null ?
                            string.Concat(x.Author.FirstName.Trim(), " ", x.Author.LastName.Trim())
                            : x.Author.Pseudonym))
                .ForMember(dest => dest.BookTitle,
                    opt => opt.MapFrom(x => x.Book.Title));
        }
    }
}
