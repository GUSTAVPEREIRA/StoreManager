using AutoMapper;
using StoreManager.Core.Domain;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.Application.Auth.Mappings
{
    public class NewFunctionMappingProfile : Profile
    {
        public NewFunctionMappingProfile()
        {
            CreateMap<NewFunctionDTO, Function>().ReverseMap();
            CreateMap<ReferenceFunctionDTO, Function>().ReverseMap();

        }
    }
}