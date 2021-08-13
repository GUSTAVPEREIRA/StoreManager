using AutoMapper;
using StoreManager.Core.Domain;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.Application.Auth.Mappings
{
    public class FunctionMappingProfile : Profile
    {
        public FunctionMappingProfile()
        {
            CreateMap<FunctionDTO, Function>().ReverseMap();
        }
    }
}