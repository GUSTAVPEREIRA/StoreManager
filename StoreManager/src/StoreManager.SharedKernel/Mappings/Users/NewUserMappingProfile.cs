using AutoMapper;
using StoreManager.Core.Domain;
using StoreManager.SharedKernel.ViewModels.Users;

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