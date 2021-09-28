using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatExplosiveConfiguration : IEntityTypeConfiguration<
        WarMaterialAndSpecialEquipmentAssignmentFormatExplosive>
    {
        public void Configure(EntityTypeBuilder<WarMaterialAndSpecialEquipmentAssignmentFormatExplosive> builder)
        {
            builder.HasKey(f => new
                { f.WarMaterialAndSpecialEquipmentAssignmentFormatId, ExplosiveCode = f.ExplosiveSerial });
        }
    }
}
