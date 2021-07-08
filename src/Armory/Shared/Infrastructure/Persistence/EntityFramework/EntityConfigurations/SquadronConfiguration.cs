using Armory.Squadrons.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class SquadronConfiguration : IEntityTypeConfiguration<Squadron>
    {
        public void Configure(EntityTypeBuilder<Squadron> builder)
        {
            builder.Property(p => p.PersonId).HasMaxLength(10);
        }
    }
}
