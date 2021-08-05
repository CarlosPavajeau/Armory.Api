using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class
        WarMaterialAndSpecialEquipmentAssignmentFormatConfiguration : IEntityTypeConfiguration<
            WarMaterialAndSpecialEquipmentAssignmentFormat>
    {
        public void Configure(EntityTypeBuilder<WarMaterialAndSpecialEquipmentAssignmentFormat> builder)
        {
            builder.Property(f => f.SquadronCode).HasMaxLength(50);
            builder.Property(f => f.SquadCode).HasMaxLength(50);
            builder.Property(f => f.TroopId).HasMaxLength(10);
        }
    }
}
