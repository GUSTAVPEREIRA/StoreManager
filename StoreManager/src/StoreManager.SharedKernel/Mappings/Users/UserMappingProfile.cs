using AutoMapper;
using StoreManager.Core.Domain;
using StoreManager.Core.ViewModels.Users;

namespace StoreManager.SharedKernel.Mappings.Users
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}