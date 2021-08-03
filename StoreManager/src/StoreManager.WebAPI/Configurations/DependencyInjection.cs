using Microsoft.Extensions.DependencyInjection;
using StoreManager.Core.Interfaces.Repositories;
using StoreManager.Core.Interfaces.Services;
using StoreManager.Core.Services;
using StoreManager.Infrastructure.Repositories;

namespace StoreManager.WebAPI.Configurations
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<IFunctionRepository, FunctionRepository>();
            services.AddScoped<IFunctionService, FunctionService>();
        }
    }
}