using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Inventory;

namespace Infrastructure.Configuration.Inventory
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Variants).WithMany(x => x.Options);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }
}