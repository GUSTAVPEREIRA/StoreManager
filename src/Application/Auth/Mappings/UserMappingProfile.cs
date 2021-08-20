using AutoMapper;
using Core.Auth;
using Core.Auth.ViewModels;

namespace Application.Auth.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}