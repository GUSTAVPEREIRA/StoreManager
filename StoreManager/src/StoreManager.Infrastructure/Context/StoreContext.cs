using Microsoft.EntityFrameworkCore;
using StoreManager.Core.Domain;
using StoreManager.Infrastructure.Configuration;

namespace StoreManager.Infrastructure.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FunctionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<Function> Functions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}