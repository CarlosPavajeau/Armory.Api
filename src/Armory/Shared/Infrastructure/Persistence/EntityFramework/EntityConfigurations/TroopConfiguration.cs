using Armory.Troopers.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class TroopConfiguration : IEntityTypeConfiguration<Troop>
    {
        public void Configure(EntityTypeBuilder<Troop> builder)
        {
            builder.Property(p => p.SquadCode).HasMaxLength(50).IsRequired();
            builder.Property(p => p.DegreeId).IsRequired();
        }
    }
}
