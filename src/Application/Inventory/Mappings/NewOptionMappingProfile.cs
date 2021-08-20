using AutoMapper;
using Core.Inventory;
using Core.Inventory.ViewModels;

namespace Application.Inventory.Mappings
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