using AutoMapper;
using IT.Valor.Core.DataTransferObjects.User;
using IT.Valor.Core.Models;

namespace IT.Valor.Core.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
        }
    }
}
