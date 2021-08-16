using AutoMapper;
using StoreManager.Core.Auth;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.Application.Auth.Mappings
{
    public class UpdateUserMappingProfile : Profile
    {
        public UpdateUserMappingProfile()
        {
            CreateMap<UpdateUserDto, User>();
        }
    }
}