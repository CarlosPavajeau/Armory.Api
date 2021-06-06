using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Users.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class ArmoryUserLogin : IEntityTypeConfiguration<IdentityUserLogin<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder.Property(p => p.LoginProvider).HasMaxLength(255);
            builder.Property(p => p.ProviderKey).HasMaxLength(255);
        }
    }
}
