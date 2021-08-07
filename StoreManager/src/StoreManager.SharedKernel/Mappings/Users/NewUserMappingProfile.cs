using AutoMapper;
using StoreManager.Core.Domain;
using StoreManager.Core.ViewModels.Users;

namespace StoreManager.SharedKernel.Mappings.Users
{
    public class NewUserMappingProfile : Profile
    {
        public NewUserMappingProfile()
        {
            CreateMap<NewUserDTO, User>();
        }
    }
}