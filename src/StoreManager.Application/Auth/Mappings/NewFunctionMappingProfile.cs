using AutoMapper;
using StoreManager.Core.Auth;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.Application.Auth.Mappings
{
    public class NewFunctionMappingProfile : Profile
    {
        public NewFunctionMappingProfile()
        {
            CreateMap<NewFunctionDto, Function>().ReverseMap();
            CreateMap<ReferenceFunctionDto, Function>().ReverseMap();
        }
    }
}