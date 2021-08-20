using Microsoft.Extensions.DependencyInjection;
using Application.Auth.Services;
using Application.Inventory.Services;
using Core.Auth.Interfaces;
using Core.Inventory.Interface;
using Infrastructure.Repositories.Auth;
using Infrastructure.Repositories.Inventory;

namespace API.Configurations
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