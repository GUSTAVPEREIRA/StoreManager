using System.Globalization;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Application.Auth.Validator;
using Application.Inventory.Validator;

namespace API.Configurations
{
    public static class FluentValidationConfiguration
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                .AddJsonOptions(x => { x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); })
                .AddFluentValidation(x =>
                {
                    x.RegisterValidatorsFromAssemblyContaining<NewFunctionValidator>();
                    x.RegisterValidatorsFromAssemblyContaining<UpdateFunctionValidator>();
                    x.RegisterValidatorsFromAssemblyContaining<FunctionValidator>();
                    x.RegisterValidatorsFromAssemblyContaining<NewOptionValidator>();
                    x.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                });
        }
    }
}