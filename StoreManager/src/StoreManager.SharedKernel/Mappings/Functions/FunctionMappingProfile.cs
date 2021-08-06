using AutoMapper;
using StoreManager.Core.Domain;
using StoreManager.Core.ViewModels.Functions;

namespace StoreManager.SharedKernel.Mappings.Functions
{
    public class FunctionMappingProfile : Profile
    {
        public FunctionMappingProfile()
        {
            CreateMap<FunctionDTO, Function>().ReverseMap();
        }
    }
}