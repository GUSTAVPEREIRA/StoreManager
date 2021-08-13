using AutoMapper;
using StoreManager.Core.Domain;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.Application.Auth.Mappings
{
    public class UpdateFunctionMappingProfile : Profile
    {
        public UpdateFunctionMappingProfile()
        {
            CreateMap<UpdateFunctionDTO, Function>().ReverseMap();
        }
    }
}