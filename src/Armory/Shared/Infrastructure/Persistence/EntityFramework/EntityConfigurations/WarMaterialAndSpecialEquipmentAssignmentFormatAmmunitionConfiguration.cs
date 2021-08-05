using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatAmmunitionConfiguration : IEntityTypeConfiguration<
        WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition>
    {
        public void Configure(EntityTypeBuilder<WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition> builder)
        {
            builder.HasKey(f => new { f.AmmunitionCode, f.WarMaterialAndSpecialEquipmentAssignmentFormatId });
        }
    }
}
