using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Inventory;

namespace Infrastructure.Configuration.Inventory
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Variants).WithMany(x => x.Products);
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
        }
    }
}