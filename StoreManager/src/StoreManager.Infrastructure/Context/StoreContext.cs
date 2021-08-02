using Microsoft.EntityFrameworkCore;
using StoreManager.Core.Domain;

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
        }

        public DbSet<Function> Functions { get; set; }
    }
}