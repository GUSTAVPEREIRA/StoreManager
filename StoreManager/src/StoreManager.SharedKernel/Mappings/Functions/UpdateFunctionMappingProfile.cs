using AutoMapper;
using StoreManager.Core.Domain;
using StoreManager.Core.ViewModels.Functions;

namespace StoreManager.Core.Mappings.Functions
{
    public class UpdateFunctionMappingProfile : Profile
    {
        public UpdateFunctionMappingProfile()
        {
            CreateMap<UpdateFunctionDTO, Function>().ReverseMap();
        }
    }
}