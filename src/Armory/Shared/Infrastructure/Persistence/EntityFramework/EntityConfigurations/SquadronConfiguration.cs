using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class SquadronConfiguration : IEntityTypeConfiguration<Squadrons.Domain.Squadron>
    {
        public void Configure(EntityTypeBuilder<Squadrons.Domain.Squadron> builder)
        {
            builder.Property(p => p.PersonId).HasMaxLength(10);
        }
    }
}
