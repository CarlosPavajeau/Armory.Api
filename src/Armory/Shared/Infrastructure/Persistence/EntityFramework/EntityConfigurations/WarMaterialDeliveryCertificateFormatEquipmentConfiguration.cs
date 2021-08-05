using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class
        WarMaterialDeliveryCertificateFormatEquipmentConfiguration : IEntityTypeConfiguration<
            WarMaterialDeliveryCertificateFormatEquipment>
    {
        public void Configure(EntityTypeBuilder<WarMaterialDeliveryCertificateFormatEquipment> builder)
        {
            builder.HasKey(f => new { f.WarMaterialDeliveryCertificateFormatId, f.EquipmentCode });
        }
    }
}
