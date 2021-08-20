using AutoMapper;
using Core.Auth;
using Core.Auth.ViewModels;

namespace Application.Auth.Mappings
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