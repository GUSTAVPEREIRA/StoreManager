using Microsoft.Extensions.DependencyInjection;
using StoreManager.Application.Interfaces.Services;
using StoreManager.Application.Services;
using StoreManager.Core.Interfaces.Repositories;
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