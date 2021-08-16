using AutoMapper;
using StoreManager.Core.Auth;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.Application.Auth.Mappings
{
    public class FunctionMappingProfile : Profile
    {
        public FunctionMappingProfile()
        {
            CreateMap<FunctionDto, Function>().ReverseMap();
        }
    }
}