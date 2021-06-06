using Armory.Users.Domain;
using Armory.Users.Infrastructure.Persistence.EntityFramework.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Armory.Users.Infrastructure.Persistence.EntityFramework
{
    public class ArmoryUserDbContext : IdentityDbContext<ArmoryUser, ArmoryRole, string>
    {
        public ArmoryUserDbContext(DbContextOptions<ArmoryUserDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ArmoryRoleConfiguration());
            builder.ApplyConfiguration(new ArmoryUserConfiguration());
            builder.ApplyConfiguration(new ArmoryUserLogin());
            builder.ApplyConfiguration(new ArmoryUserTokenConfiguration());
        }
    }
}
