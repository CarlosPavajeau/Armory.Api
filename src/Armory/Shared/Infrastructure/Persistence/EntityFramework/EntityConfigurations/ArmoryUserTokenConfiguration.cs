using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class ArmoryUserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            builder.Property(p => p.LoginProvider).HasMaxLength(255);
            builder.Property(p => p.Name).HasMaxLength(255);
        }
    }
}
