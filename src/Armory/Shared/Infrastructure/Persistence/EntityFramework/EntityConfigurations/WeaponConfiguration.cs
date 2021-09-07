using Armory.Armament.Weapons.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class WeaponConfiguration : IEntityTypeConfiguration<Weapon>
    {
        public void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.HasIndex(w => w.Series).IsUnique();

            builder.Property(w => w.State).HasDefaultValue(WeaponState.NotAssigned);
        }
    }
}
