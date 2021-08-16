using AutoMapper;
using StoreManager.Core.Auth;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.Application.Auth.Mappings
{
    public class NewUserMappingProfile : Profile
    {
        public NewUserMappingProfile()
        {
            CreateMap<NewUserDto, User>();
        }
    }
}