using AutoMapper;
using StoreManager.Core.Auth;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.Application.Auth.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}