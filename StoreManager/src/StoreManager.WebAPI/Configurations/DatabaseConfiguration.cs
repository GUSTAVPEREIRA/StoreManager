namespace StoreManager.WebAPI.Configurations
{
    public class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClinicCorporateContext>(options => options.UseSqlServer(configuration.GetConnectionString("StoreManagerDB")));
        }

        public static void UseDatabaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ClinicCorporateContext>();
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}