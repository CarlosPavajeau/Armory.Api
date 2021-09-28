using Armory.Armament.Ammunition.Application.CheckExists;
using Armory.Armament.Ammunition.Application.Create;
using Armory.Armament.Ammunition.Application.Find;
using Armory.Armament.Ammunition.Application.SearchAll;
using Armory.Armament.Equipments.Application.CheckExists;
using Armory.Armament.Equipments.Application.Create;
using Armory.Armament.Equipments.Application.Find;
using Armory.Armament.Equipments.Application.SearchAll;
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
using Armory.Degrees.Application.Create;
using Armory.Degrees.Application.Find;
using Armory.Degrees.Application.SearchAll;
using Armory.Degrees.Application.SearchAllByRank;
using Armory.Fireteams.Application.CheckExists;
using Armory.Fireteams.Application.Create;
using Armory.Fireteams.Application.Find;
using Armory.Fireteams.Application.SearchAll;
using Armory.Fireteams.Application.SearchAllByFlight;
using Armory.Flights.Application.CheckExists;
using Armory.Flights.Application.Create;
using Armory.Flights.Application.Find;
using Armory.Flights.Application.SearchAll;
using Armory.Formats.AssignedWeaponMagazineFormats.Application.AddItem;
using Armory.Formats.AssignedWeaponMagazineFormats.Application.Create;
using Armory.Formats.AssignedWeaponMagazineFormats.Application.Find;
using Armory.Formats.AssignedWeaponMagazineFormats.Application.Generate;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Create;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Find;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Generate;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Create;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Find;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Generate;
using Armory.People.Application.CheckExists;
using Armory.People.Application.Create;
using Armory.People.Application.Delete;
using Armory.People.Application.Find;
using Armory.People.Application.SearchAll;
using Armory.People.Application.SearchAllByRank;
using Armory.People.Application.SearchAllByRole;
using Armory.People.Application.SearchByArmoryUserId;
using Armory.People.Application.Update;
using Armory.People.Application.UpdateDegree;
using Armory.Ranks.Application.Create;
using Armory.Ranks.Application.Find;
using Armory.Ranks.Application.SearchAll;
using Armory.Squads.Application.CheckExists;
using Armory.Squads.Application.Create;
using Armory.Squads.Application.Find;
using Armory.Squads.Application.SearchAll;
using Armory.Troopers.Application.CheckExists;
using Armory.Troopers.Application.Create;
using Armory.Troopers.Application.Find;
using Armory.Troopers.Application.SearchAll;
using Armory.Troopers.Application.SearchAllByFireteam;
using Armory.Troopers.Application.Update;
using Armory.Users.Application.AddToRole;
using Armory.Users.Application.Authenticate;
using Armory.Users.Application.ChangePassword;
using Armory.Users.Application.CheckExists;
using Armory.Users.Application.ConfirmEmail;
using Armory.Users.Application.Create;
using Armory.Users.Application.GenerateEmailConfirmationToken;
using Armory.Users.Application.GenerateJwt;
using Armory.Users.Application.GeneratePasswordResetToken;
using Armory.Users.Application.ResetPassword;
using Armory.Users.Application.SearchAllRoles;
using Microsoft.Extensions.DependencyInjection;

namespace Armory.Api.Extensions
{
    public static class Application
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ArmoryUserCreator, ArmoryUserCreator>();
            services.AddScoped<ArmoryUserAuthenticator, ArmoryUserAuthenticator>();
            services.AddScoped<JwtGenerator, JwtGenerator>();
            services.AddScoped<PasswordResetTokenGenerator, PasswordResetTokenGenerator>();
            services.AddScoped<PasswordRestorer, PasswordRestorer>();
            services.AddScoped<PasswordChanger, PasswordChanger>();
            services.AddScoped<EmailConfirmationTokenGenerator, EmailConfirmationTokenGenerator>();
            services.AddScoped<EmailConfirmer, EmailConfirmer>();
            services.AddScoped<RoleAggregator, RoleAggregator>();
            services.AddScoped<RoleSearcher, RoleSearcher>();
            services.AddScoped<ArmoryUserExistsChecker, ArmoryUserExistsChecker>();

            services.AddScoped<PersonCreator, PersonCreator>();
            services.AddScoped<PersonDeleter, PersonDeleter>();
            services.AddScoped<PeopleSearcher, PeopleSearcher>();
            services.AddScoped<PeopleByRoleSearcher, PeopleByRoleSearcher>();
            services.AddScoped<PersonByArmoryUserIdSearcher, PersonByArmoryUserIdSearcher>();
            services.AddScoped<PeopleByRankSearcher, PeopleByRankSearcher>();
            services.AddScoped<PersonFinder, PersonFinder>();
            services.AddScoped<PersonUpdater, PersonUpdater>();
            services.AddScoped<PersonExistsChecker, PersonExistsChecker>();
            services.AddScoped<PersonDegreeUpdater, PersonDegreeUpdater>();

            services.AddScoped<SquadCreator, SquadCreator>();
            services.AddScoped<SquadExistsChecker, SquadExistsChecker>();
            services.AddScoped<SquadFinder, SquadFinder>();
            services.AddScoped<SquadsSearcher, SquadsSearcher>();

            services.AddScoped<FlightCreator, FlightCreator>();
            services.AddScoped<FlightFinder, FlightFinder>();
            services.AddScoped<FlightExistsChecker, FlightExistsChecker>();
            services.AddScoped<FlightsSearcher, FlightsSearcher>();

            services.AddScoped<FireteamCreator, FireteamCreator>();
            services.AddScoped<FireteamFinder, FireteamFinder>();
            services.AddScoped<FireteamExistsChecker, FireteamExistsChecker>();
            services.AddScoped<FireteamsSearcher, FireteamsSearcher>();
            services.AddScoped<FireteamsByFlightSearcher, FireteamsByFlightSearcher>();

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

            services.AddScoped<EquipmentCreator, EquipmentCreator>();
            services.AddScoped<AllEquipmentsSearcher, AllEquipmentsSearcher>();
            services.AddScoped<EquipmentFinder, EquipmentFinder>();
            services.AddScoped<EquipmentExistsChecker, EquipmentExistsChecker>();
            services.AddScoped<EquipmentUpdater, EquipmentUpdater>();

            services.AddScoped<ExplosiveCreator, ExplosiveCreator>();
            services.AddScoped<AllExplosivesSearcher, AllExplosivesSearcher>();
            services.AddScoped<ExplosiveFinder, ExplosiveFinder>();
            services.AddScoped<ExplosiveExistsChecker, ExplosiveExistsChecker>();
            services.AddScoped<ExplosiveUpdater, ExplosiveUpdater>();
            services.AddScoped<ExplosivesByFlightSearcher, ExplosivesByFlightSearcher>();

            services.AddScoped<RankCreator, RankCreator>();
            services.AddScoped<RankFinder, RankFinder>();
            services.AddScoped<AllRanksSearcher, AllRanksSearcher>();

            services.AddScoped<DegreeCreator, DegreeCreator>();
            services.AddScoped<DegreeFinder, DegreeFinder>();
            services.AddScoped<AllDegreesSearcher, AllDegreesSearcher>();
            services.AddScoped<DegreesByRankSearcher, DegreesByRankSearcher>();

            services.AddScoped<TroopCreator, TroopCreator>();
            services.AddScoped<TroopFinder, TroopFinder>();
            services.AddScoped<TroopExistsChecker, TroopExistsChecker>();
            services.AddScoped<AllTroopsSearcher, AllTroopsSearcher>();
            services.AddScoped<TroopersByFireteamSearcher, TroopersByFireteamSearcher>();
            services.AddScoped<TroopUpdater, TroopUpdater>();

            services
                .AddScoped<WarMaterialAndSpecialEquipmentAssignmentFormatCreator,
                    WarMaterialAndSpecialEquipmentAssignmentFormatCreator>();
            services
                .AddScoped<WarMaterialAndSpecialEquipmentAssignmentFormatFinder,
                    WarMaterialAndSpecialEquipmentAssignmentFormatFinder>();
            services
                .AddScoped<WarMaterialAndSpecialEquipmentAssignmentFormatGenerator,
                    WarMaterialAndSpecialEquipmentAssignmentFormatGenerator>();

            services
                .AddScoped<WarMaterialDeliveryCertificateFormatCreator, WarMaterialDeliveryCertificateFormatCreator>();
            services
                .AddScoped<WarMaterialDeliveryCertificateFormatFinder, WarMaterialDeliveryCertificateFormatFinder>();
            services
                .AddScoped<WarMaterialDeliveryCertificateFormatGenerator,
                    WarMaterialDeliveryCertificateFormatGenerator>();

            services.AddScoped<AssignedWeaponMagazineFormatCreator, AssignedWeaponMagazineFormatCreator>();
            services.AddScoped<AssignedWeaponMagazineFormatFinder, AssignedWeaponMagazineFormatFinder>();
            services.AddScoped<AssignedWeaponMagazineFormatGenerator, AssignedWeaponMagazineFormatGenerator>();
            services.AddScoped<AssignedWeaponMagazineFormatItemAdder, AssignedWeaponMagazineFormatItemAdder>();

            return services;
        }
    }
}
