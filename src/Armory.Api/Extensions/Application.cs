using Armory.Armament.Ammunition.Application.Create;
using Armory.Armament.Ammunition.Application.SearchAll;
using Armory.Armament.Ammunition.Application.SearchByCode;
using Armory.Armament.Ammunition.Application.Update;
using Armory.Armament.Weapons.Application.Create;
using Armory.Armament.Weapons.Application.SearchAll;
using Armory.Armament.Weapons.Application.SearchByCode;
using Armory.Armament.Weapons.Application.Update;
using Armory.People.Application.CheckExists;
using Armory.People.Application.Create;
using Armory.People.Application.Delete;
using Armory.People.Application.SearchAll;
using Armory.People.Application.SearchAllByRole;
using Armory.People.Application.SearchByArmoryUserId;
using Armory.People.Application.SearchById;
using Armory.People.Application.Update;
using Armory.Shared.Extensions;
using Armory.Shared.Helpers;
using Armory.Squadrons.Application.Create;
using Armory.Squadrons.Application.SearchAll;
using Armory.Squadrons.Application.SearchByCode;
using Armory.Squads.Application.Create;
using Armory.Squads.Application.SearchAll;
using Armory.Squads.Application.SearchByCode;
using Armory.Users.Application.AddToRole;
using Armory.Users.Application.Authenticate;
using Armory.Users.Application.ChangePassword;
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

            services.AddScoped<PersonCreator, PersonCreator>();
            services.AddScoped<PersonDeleter, PersonDeleter>();
            services.AddScoped<PeopleSearcher, PeopleSearcher>();
            services.AddScoped<PeopleByRoleSearcher, PeopleByRoleSearcher>();
            services.AddScoped<PersonByArmoryUserIdSearcher, PersonByArmoryUserIdSearcher>();
            services.AddScoped<PersonByIdSearcher, PersonByIdSearcher>();
            services.AddScoped<PersonUpdater, PersonUpdater>();
            services.AddScoped<PersonExistsChecker, PersonExistsChecker>();

            services.AddScoped<SquadronCreator, SquadronCreator>();
            services.AddScoped<SquadronByCodeSearcher, SquadronByCodeSearcher>();
            services.AddScoped<SquadronsSearcher, SquadronsSearcher>();

            services.AddScoped<SquadCreator, SquadCreator>();
            services.AddScoped<SquadsSearcher, SquadsSearcher>();
            services.AddScoped<SquadByCodeSearcher, SquadByCodeSearcher>();

            services.AddScoped<WeaponCreator, WeaponCreator>();
            services.AddScoped<WeaponSearcher, WeaponSearcher>();
            services.AddScoped<WeaponByCodeSearcher, WeaponByCodeSearcher>();
            services.AddScoped<WeaponUpdater, WeaponUpdater>();

            services.AddScoped<AmmunitionCreator, AmmunitionCreator>();
            services.AddScoped<AmmunitionSearcher, AmmunitionSearcher>();
            services.AddScoped<AmmunitionByCodeSearcher, AmmunitionByCodeSearcher>();
            services.AddScoped<AmmunitionUpdater, AmmunitionUpdater>();

            services.AddCommandServices(AssemblyHelper.GetInstance(Assemblies.Armory));
            services.AddQueryServices(AssemblyHelper.GetInstance(Assemblies.Armory));

            return services;
        }
    }
}
