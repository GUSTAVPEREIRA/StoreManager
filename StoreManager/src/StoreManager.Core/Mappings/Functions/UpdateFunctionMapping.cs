using AutoMapper;
using StoreManager.Core.Domain;

namespace StoreManager.Core.Mappings.Functions
{
    public class UpdateFunctionMapping : Profile
    {
        public UpdateFunctionMapping()
        {
            CreateMap<UpdateFunctionMapping, Function>();
        }
    }
}