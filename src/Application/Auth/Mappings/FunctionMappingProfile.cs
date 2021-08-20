using AutoMapper;
using Core.Auth;
using Core.Auth.ViewModels;

namespace Application.Auth.Mappings
{
    public class FunctionMappingProfile : Profile
    {
        public FunctionMappingProfile()
        {
            CreateMap<FunctionDto, Function>().ReverseMap();
        }
    }
}