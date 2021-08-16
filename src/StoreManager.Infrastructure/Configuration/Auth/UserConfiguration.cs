using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManager.Core.Auth;

namespace StoreManager.Infrastructure.Configuration.Auth
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Login).IsUnique();
            builder.Property(u => u.Login).HasMaxLength(20).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(200).IsRequired();
            builder.HasMany(u => u.Functions).WithMany(u => u.Users);
            builder.Property(u => u.CreatedAt).IsRequired();
        }
    }
}