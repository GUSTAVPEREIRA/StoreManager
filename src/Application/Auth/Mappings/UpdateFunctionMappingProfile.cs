using AutoMapper;
using Core.Auth;
using Core.Auth.ViewModels;

namespace Application.Auth.Mappings
{
    public class UpdateFunctionMappingProfile : Profile
    {
        public UpdateFunctionMappingProfile()
        {
            CreateMap<UpdateFunctionDto, Function>().ReverseMap();
        }
    }
}