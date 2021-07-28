using Armory.Formats.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class
        WarMaterialDeliveryCertificateFormatExplosiveConfiguration : IEntityTypeConfiguration<
            WarMaterialDeliveryCertificateFormatExplosive>
    {
        public void Configure(EntityTypeBuilder<WarMaterialDeliveryCertificateFormatExplosive> builder)
        {
            builder.HasKey(f => new {f.WarMaterialDeliveryCertificateFormatId, f.ExplosiveCode});
        }
    }
}
