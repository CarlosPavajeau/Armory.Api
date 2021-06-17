using Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations;
using Armory.Users.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework
{
    public class ArmoryDbContext : IdentityDbContext<ArmoryUser, ArmoryRole, string>
    {
        public DbSet<Squadrons.Domain.Squadron> Squadrons { get; set; }

        public ArmoryDbContext(DbContextOptions<ArmoryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ArmoryUserConfiguration());
            builder.ApplyConfiguration(new ArmoryRoleConfiguration());
            builder.ApplyConfiguration(new ArmoryUserLoginConfiguration());
            builder.ApplyConfiguration(new ArmoryUserTokenConfiguration());
            builder.ApplyConfiguration(new SquadronConfiguration());
        }
    }
}
