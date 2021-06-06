using Armory.Users.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Users.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class ArmoryUserConfiguration : IEntityTypeConfiguration<ArmoryUser>
    {
        public void Configure(EntityTypeBuilder<ArmoryUser> builder)
        {
            builder.Property(p => p.Id).HasMaxLength(255);
            builder.Property(p => p.UserName).HasMaxLength(15);
            builder.Property(p => p.NormalizedUserName).HasMaxLength(15);
            builder.Property(p => p.PasswordHash).HasMaxLength(255);
            builder.Property(p => p.PhoneNumber).HasMaxLength(10);
            builder.Property(p => p.Email).HasMaxLength(127);
            builder.Property(p => p.NormalizedEmail).HasMaxLength(127);

            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasIndex(p => p.PhoneNumber).IsUnique();
        }
    }
}
