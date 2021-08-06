using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class
        WarMaterialDeliveryCertificateFormatAmmunitionConfiguration : IEntityTypeConfiguration<
            WarMaterialDeliveryCertificateFormatAmmunition>
    {
        public void Configure(EntityTypeBuilder<WarMaterialDeliveryCertificateFormatAmmunition> builder)
        {
            builder.HasKey(f => new { f.WarMaterialDeliveryCertificateFormatId, f.AmmunitionCode });
        }
    }
}
