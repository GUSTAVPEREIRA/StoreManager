using AutoMapper;
using Core.Auth;
using Core.Auth.ViewModels;

namespace Application.Auth.Mappings
{
    public class UpdateUserMappingProfile : Profile
    {
        public UpdateUserMappingProfile()
        {
            CreateMap<UpdateUserDto, User>();
        }
    }
}