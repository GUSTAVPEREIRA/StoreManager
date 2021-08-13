using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreManager.WebAPI.Configurations;

namespace StoreManager.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDatabaseConfiguration(Configuration);
            services.AddJwtConfiguration(Configuration);
            services.AddFluentValidationConfiguration();
            services.AddSwaggerConfiguration();
            services.AddAutoMapperConfig();
            services.AddDependencyInjectionConfig();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDatabaseConfiguration();
            app.UseSwaggerConfiguration();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.AddJwtConfiguration();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}