using AutoMapper;
using StoreManager.Core.Auth;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.Application.Auth.Mappings
{
    public class UpdateFunctionMappingProfile : Profile
    {
        public UpdateFunctionMappingProfile()
        {
            CreateMap<UpdateFunctionDto, Function>().ReverseMap();
        }
    }
}