using Microsoft.EntityFrameworkCore;
using StoreManager.Core.Auth;
using StoreManager.Core.Inventory;
using StoreManager.Infrastructure.Configuration.Auth;
using StoreManager.Infrastructure.Configuration.Inventory;

namespace StoreManager.Infrastructure.Context
{
    public class StoreContext : DbContext
    {
        public DbSet<Function> Functions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Variant> Variants { get; set; }

        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FunctionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OptionConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new VariantConfiguration());
        }
    }
}