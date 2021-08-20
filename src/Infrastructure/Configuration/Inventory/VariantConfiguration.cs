using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Inventory;

namespace Infrastructure.Configuration.Inventory
{
    public class VariantConfiguration : IEntityTypeConfiguration<Variant>
    {
        public void Configure(EntityTypeBuilder<Variant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Options).WithMany(x => x.Variants);
            builder.HasMany(x => x.Products).WithMany(x => x.Variants);
            builder.Property(x => x.Description).HasMaxLength(300);
            builder.Property(x => x.Price).HasPrecision(18, 4).IsRequired();
        }
    }
}