using Armory.Degrees.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class DegreeConfiguration : IEntityTypeConfiguration<Degree>
    {
        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            builder.Property(p => p.RankId).IsRequired();
        }
    }
}
