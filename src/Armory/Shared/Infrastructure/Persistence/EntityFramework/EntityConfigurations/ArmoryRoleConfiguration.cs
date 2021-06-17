using Armory.Users.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class ArmoryRoleConfiguration : IEntityTypeConfiguration<ArmoryRole>
    {
        public void Configure(EntityTypeBuilder<ArmoryRole> builder)
        {
            builder.Property(p => p.Id).HasMaxLength(255);
            builder.Property(p => p.Name).HasMaxLength(255);
            builder.Property(p => p.NormalizedName).HasMaxLength(255);
        }
    }
}
