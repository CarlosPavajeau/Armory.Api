using Armory.People.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.ArmoryUserId).HasMaxLength(255);
            builder.HasIndex(p => p.ArmoryUserId).IsUnique();
            builder.HasOne(p => p.ArmoryUser)
                .WithOne(a => a.Person)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
