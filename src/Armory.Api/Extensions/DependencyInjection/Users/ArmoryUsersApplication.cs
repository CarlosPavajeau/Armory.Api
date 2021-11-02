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

namespace Armory.Api.Extensions.DependencyInjection.Users
{
    public static class ArmoryUsersApplication
    {
        public static IServiceCollection AddArmoryUsersApplication(this IServiceCollection services)
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

            return services;
        }
    }
}
