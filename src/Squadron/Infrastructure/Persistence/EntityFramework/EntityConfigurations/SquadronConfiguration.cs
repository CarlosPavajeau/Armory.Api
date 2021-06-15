using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Squadron.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class SquadronConfiguration : IEntityTypeConfiguration<Domain.Squadron>
    {
        public void Configure(EntityTypeBuilder<Domain.Squadron> builder)
        {
            builder.Property(p => p.ArmoryUserId).HasMaxLength(255);
        }
    }
}
