using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatEquipmentConfiguration : IEntityTypeConfiguration<
        WarMaterialAndSpecialEquipmentAssignmentFormatEquipment>
    {
        public void Configure(EntityTypeBuilder<WarMaterialAndSpecialEquipmentAssignmentFormatEquipment> builder)
        {
            builder.HasKey(f => new { f.WarMaterialAndSpecialEquipmentAssignmentFormatId, f.EquipmentCode });
        }
    }
}
