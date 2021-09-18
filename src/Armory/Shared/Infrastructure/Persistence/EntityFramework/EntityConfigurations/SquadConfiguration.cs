using Armory.Squads.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class SquadConfiguration : IEntityTypeConfiguration<Squad>
    {
        public void Configure(EntityTypeBuilder<Squad> builder)
        {
            builder.Property(p => p.PersonId).HasMaxLength(10);
            builder.Property(p => p.FlightCode).HasMaxLength(50);
        }
    }
}
