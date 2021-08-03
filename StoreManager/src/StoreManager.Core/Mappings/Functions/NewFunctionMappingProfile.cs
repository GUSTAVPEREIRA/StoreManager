using AutoMapper;
using StoreManager.Core.Domain;
using StoreManager.SharedKernel.ViewModels;

namespace StoreManager.Core.Mappings.Functions
{
    public class NewFunctionMappingProfile : Profile
    {
        public NewFunctionMappingProfile()
        {
            CreateMap<NewFunctionDTO, Function>();
            CreateMap<Function, NewFunctionDTO>();
        }
    }
}