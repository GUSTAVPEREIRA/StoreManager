using Microsoft.Extensions.DependencyInjection;
using Application.Auth.Mappings;
using Application.Inventory.Mappings;

namespace API.Configurations
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
                typeof(UserMappingProfile),
                typeof(NewOptionMappingProfile));
        }
    }
}