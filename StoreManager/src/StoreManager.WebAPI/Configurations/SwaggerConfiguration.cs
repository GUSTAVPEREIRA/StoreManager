using System.IO;
using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

namespace StoreManager.WebAPI.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Store Manager",
                    Version = "v1",
                    Description = "API construida para gerenciar uma loja!",
                    Contact = new OpenApiContact
                    {
                        Email = "gugupereira123@hotmail.com",
                        Name = "Gustavo Antonio Pereira",
                        Url = new Uri("https://github.com/GUSTAVPEREIRA")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://github.com/GUSTAVPEREIRA/StoreManager/blob/main/LICENSE")
                    },
                    TermsOfService = new Uri("https://github.com/GUSTAVPEREIRA/StoreManager/blob/main/LICENSE")
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                
                xmlPath = Path.Combine(AppContext.BaseDirectory, "StoreManager.Core.xml");
                c.IncludeXmlComments(xmlPath);
                xmlPath = Path.Combine(AppContext.BaseDirectory, "StoreManager.SharedKernel.xml");
                c.IncludeXmlComments(xmlPath);
            });

            services.AddFluentValidationRulesToSwagger();
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "Store Manager V1");
            });
        }
    }
}