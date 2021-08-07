using AutoMapper;
using StoreManager.Core.Domain;
using StoreManager.Core.ViewModels.Functions;

namespace StoreManager.Core.Mappings.Functions
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