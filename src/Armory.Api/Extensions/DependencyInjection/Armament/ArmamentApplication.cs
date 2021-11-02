using Armory.Armament.Ammunition.Application.CheckExists;
using Armory.Armament.Ammunition.Application.Create;
using Armory.Armament.Ammunition.Application.Find;
using Armory.Armament.Ammunition.Application.SearchAll;
using Armory.Armament.Ammunition.Application.SearchAllByFlight;
using Armory.Armament.Equipments.Application.CheckExists;
using Armory.Armament.Equipments.Application.Create;
using Armory.Armament.Equipments.Application.Find;
using Armory.Armament.Equipments.Application.SearchAll;
using Armory.Armament.Equipments.Application.SearchAllByFlight;
using Armory.Armament.Equipments.Application.Update;
using Armory.Armament.Explosives.Application.CheckExists;
using Armory.Armament.Explosives.Application.Create;
using Armory.Armament.Explosives.Application.Find;
using Armory.Armament.Explosives.Application.SearchAll;
using Armory.Armament.Explosives.Application.SearchAllByFlight;
using Armory.Armament.Explosives.Application.Update;
using Armory.Armament.Weapons.Application.AssignHolder;
using Armory.Armament.Weapons.Application.CheckExists;
using Armory.Armament.Weapons.Application.Create;
using Armory.Armament.Weapons.Application.Find;
using Armory.Armament.Weapons.Application.GenerateQR;
using Armory.Armament.Weapons.Application.SearchAll;
using Armory.Armament.Weapons.Application.SearchAllByFlight;
using Armory.Armament.Weapons.Application.Update;
using Microsoft.Extensions.DependencyInjection;

namespace Armory.Api.Extensions.DependencyInjection.Armament
{
    public static class ArmamentApplication
    {
        public static IServiceCollection AddArmamentApplication(this IServiceCollection services)
        {
            services.AddScoped<WeaponCreator, WeaponCreator>();
            services.AddScoped<WeaponSearcher, WeaponSearcher>();
            services.AddScoped<WeaponFinder, WeaponFinder>();
            services.AddScoped<WeaponExistsChecker, WeaponExistsChecker>();
            services.AddScoped<WeaponUpdater, WeaponUpdater>();
            services.AddScoped<WeaponHolderAssigner, WeaponHolderAssigner>();
            services.AddScoped<WeaponQrGenerator, WeaponQrGenerator>();
            services.AddScoped<WeaponsByFlightSearcher, WeaponsByFlightSearcher>();

            services.AddScoped<AmmunitionCreator, AmmunitionCreator>();
            services.AddScoped<AmmunitionSearcher, AmmunitionSearcher>();
            services.AddScoped<AmmunitionFinder, AmmunitionFinder>();
            services.AddScoped<AmmunitionExistsChecker, AmmunitionExistsChecker>();
            services.AddScoped<AmmunitionByFlightSearcher, AmmunitionByFlightSearcher>();

            services.AddScoped<EquipmentCreator, EquipmentCreator>();
            services.AddScoped<AllEquipmentsSearcher, AllEquipmentsSearcher>();
            services.AddScoped<EquipmentFinder, EquipmentFinder>();
            services.AddScoped<EquipmentExistsChecker, EquipmentExistsChecker>();
            services.AddScoped<EquipmentUpdater, EquipmentUpdater>();
            services.AddScoped<EquipmentsByFlightSearcher, EquipmentsByFlightSearcher>();

            services.AddScoped<ExplosiveCreator, ExplosiveCreator>();
            services.AddScoped<AllExplosivesSearcher, AllExplosivesSearcher>();
            services.AddScoped<ExplosiveFinder, ExplosiveFinder>();
            services.AddScoped<ExplosiveExistsChecker, ExplosiveExistsChecker>();
            services.AddScoped<ExplosiveUpdater, ExplosiveUpdater>();
            services.AddScoped<ExplosivesByFlightSearcher, ExplosivesByFlightSearcher>();

            return services;
        }
    }
}
