using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class
        WarMaterialDeliveryCertificateFormatWeaponConfiguration : IEntityTypeConfiguration<
            WarMaterialDeliveryCertificateFormatWeapon>
    {
        public void Configure(EntityTypeBuilder<WarMaterialDeliveryCertificateFormatWeapon> builder)
        {
            builder.HasKey(x => new { x.WarMaterialDeliveryCertificateFormatId, x.WeaponCode });
        }
    }
}
