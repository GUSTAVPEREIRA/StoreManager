using AutoMapper;
using StoreManager.Core.Domain;
using StoreManager.SharedKernel.ViewModels;

namespace StoreManager.Core.Mappings.Functions
{
    public class FunctionMappingProfile : Profile
    {
        public FunctionMappingProfile()
        {
            CreateMap<FunctionDTO, Function>().ReverseMap();
        }
    }
}