using Armory.Armament.Ammunition.Domain;
using Armory.Armament.Equipments.Domain;
using Armory.Armament.Explosives.Domain;
using Armory.Armament.Weapons.Domain;
using Armory.Degrees.Domain;
using Armory.Formats.AssignedWeaponMagazineFormats.Domain;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;
using Armory.People.Domain;
using Armory.Ranks.Domain;
using Armory.Squadrons.Domain;
using Armory.Squads.Domain;
using Armory.Troopers.Domain;
using Armory.Users.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework
{
    public class ArmoryDbContext : IdentityDbContext<ArmoryUser, ArmoryRole, string>
    {
        public ArmoryDbContext(DbContextOptions<ArmoryDbContext> options) : base(options)
        {
        }

        public DbSet<Squadron> Squadrons { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Ammunition> Ammunition { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Explosive> Explosives { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Troop> Troopers { get; set; }

        public DbSet<WarMaterialAndSpecialEquipmentAssignmentFormat> WarMaterialAndSpecialEquipmentAssignmentFormats
        {
            get;
            set;
        }

        public DbSet<WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition>
            WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition { get; set; }

        public DbSet<WarMaterialAndSpecialEquipmentAssignmentFormatEquipment>
            WarMaterialAndSpecialEquipmentAssignmentFormatEquipments { get; set; }

        public DbSet<WarMaterialAndSpecialEquipmentAssignmentFormatExplosive>
            WarMaterialAndSpecialEquipmentAssignmentFormatExplosives { get; set; }

        public DbSet<WarMaterialAndSpecialEquipmentAssignmentFormatWeapon>
            WarMaterialAndSpecialEquipmentAssignmentFormatWeapons { get; set; }

        public DbSet<WarMaterialDeliveryCertificateFormat> WarMaterialDeliveryCertificateFormats { get; set; }

        public DbSet<WarMaterialDeliveryCertificateFormatAmmunition> WarMaterialDeliveryCertificateFormatAmmunition
        {
            get;
            set;
        }

        public DbSet<WarMaterialDeliveryCertificateFormatEquipment> WarMaterialDeliveryCertificateFormatEquipments
        {
            get;
            set;
        }

        public DbSet<WarMaterialDeliveryCertificateFormatExplosive> WarMaterialDeliveryCertificateFormatExplosives
        {
            get;
            set;
        }

        public DbSet<WarMaterialDeliveryCertificateFormatWeapon> WarMaterialDeliveryCertificateFormatWeapons
        {
            get;
            set;
        }

        public DbSet<AssignedWeaponMagazineFormat> AssignedWeaponMagazineFormats { get; set; }
        public DbSet<AssignedWeaponMagazineFormatItem> AssignedWeaponMagazineFormatItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ArmoryDbContext).Assembly);
        }
    }
}
