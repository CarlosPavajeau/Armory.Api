using Armory.Armament.Weapons.Domain;
using Armory.People.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations;
using Armory.Squadrons.Domain;
using Armory.Squads.Domain;
using Armory.Users.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework
{
    public class ArmoryDbContext : IdentityDbContext<ArmoryUser, ArmoryRole, string>
    {
        public DbSet<Squadron> Squadrons { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

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
            builder.ApplyConfiguration(new SquadConfiguration());
        }
    }
}
