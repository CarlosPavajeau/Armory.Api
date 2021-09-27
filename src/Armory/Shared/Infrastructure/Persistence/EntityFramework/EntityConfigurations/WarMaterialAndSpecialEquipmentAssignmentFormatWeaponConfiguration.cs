using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class
        WarMaterialAndSpecialEquipmentAssignmentFormatWeaponConfiguration : IEntityTypeConfiguration<
            WarMaterialAndSpecialEquipmentAssignmentFormatWeapon>
    {
        public void Configure(EntityTypeBuilder<WarMaterialAndSpecialEquipmentAssignmentFormatWeapon> builder)
        {
            builder.HasIndex(x => new { x.WarMaterialAndSpecialEquipmentAssignmentFormatId, x.WeaponSeries })
                .IsUnique();
        }
    }
}
