using Microsoft.Extensions.DependencyInjection;
using StoreManager.Application.Auth.Mappings;

namespace StoreManager.WebAPI.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NewFunctionMappingProfile),
            typeof(UpdateFunctionMappingProfile),
            typeof(FunctionMappingProfile),
            typeof(NewUserMappingProfile),
            typeof(UpdateUserMappingProfile),
            typeof(UserMappingProfile));
        }
    }
}