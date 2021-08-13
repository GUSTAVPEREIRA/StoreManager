using Microsoft.Extensions.DependencyInjection;
using StoreManager.Application.Auth.Services;
using StoreManager.Application.Inventory.Services;
using StoreManager.Core.Auth.Interfaces;
using StoreManager.Core.Inventory.Interface;
using StoreManager.Infrastructure.Repositories.Auth;
using StoreManager.Infrastructure.Repositories.Inventory;

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
            
            services.AddScoped<IOptionRepository, OptionRepository>();
            services.AddScoped<IOptionService, OptionService>();
            
        }
    }
}