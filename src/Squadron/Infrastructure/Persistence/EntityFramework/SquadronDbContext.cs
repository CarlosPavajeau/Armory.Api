using Armory.Squadron.Infrastructure.Persistence.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Armory.Squadron.Infrastructure.Persistence.EntityFramework
{
    public class SquadronDbContext : DbContext
    {
        public DbSet<Armory.Squadron.Domain.Squadron> Squadrons { get; set; }

        public SquadronDbContext(DbContextOptions<SquadronDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SquadronConfiguration());
        }
    }
}
