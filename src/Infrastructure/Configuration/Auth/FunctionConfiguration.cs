using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Auth;

namespace Infrastructure.Configuration.Auth
{
    public class FunctionConfiguration : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Admin).HasDefaultValue(false).IsRequired();
        }
    }
}