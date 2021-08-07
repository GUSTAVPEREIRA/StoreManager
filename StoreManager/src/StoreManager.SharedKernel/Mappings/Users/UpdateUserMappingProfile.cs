using AutoMapper;
using StoreManager.Core.Domain;
using StoreManager.Core.ViewModels.Users;

namespace StoreManager.SharedKernel.Mappings.Users
{
    public class UpdateUserMappingProfile : Profile
    {
        public UpdateUserMappingProfile()
        {
            CreateMap<UpdateUserDTO, User>();
        }
    }
}