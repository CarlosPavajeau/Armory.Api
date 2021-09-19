using Armory.Fireteams.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class FireteamConfiguration : IEntityTypeConfiguration<Fireteam>
    {
        public void Configure(EntityTypeBuilder<Fireteam> builder)
        {
            builder.Property(p => p.PersonId).HasMaxLength(10);
            builder.Property(p => p.FlightCode).HasMaxLength(50);
        }
    }
}
