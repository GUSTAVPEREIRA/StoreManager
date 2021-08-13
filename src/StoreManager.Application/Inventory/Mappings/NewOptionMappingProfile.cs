using AutoMapper;
using StoreManager.Core.Inventory;
using StoreManager.Core.Inventory.ViewModels;

namespace StoreManager.Application.Inventory.Mappings
{
    public class NewOptionMappingProfile : Profile
    {
        public NewOptionMappingProfile()
        {
            CreateMap<Option, NewOptionDto>().ReverseMap();
            CreateMap<Option, OptionDto>().ReverseMap();
        }
    }
}