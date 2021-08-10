using Microsoft.Extensions.DependencyInjection;
using StoreManager.Application.Services;
using StoreManager.Core.Interfaces.Repositories;
using StoreManager.Core.Interfaces.Services;
using StoreManager.Infrastructure.Repositories;

namespace StoreManager.WebAPI.Configurations
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddSingleton<IJwtService, JwtService>();
            services.AddScoped<IFunctionService, FunctionService>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped<IFunctionRepository, FunctionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}