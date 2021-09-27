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
            builder.HasIndex(x => new { x.WarMaterialDeliveryCertificateFormatId, x.WeaponSeries }).IsUnique();
        }
    }
}
