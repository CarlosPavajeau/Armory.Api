using Armory.Shared.Extensions;
using Armory.Shared.Helpers;
using Armory.Squadrons.Application.Create;
using Armory.Squadrons.Application.SearchAll;
using Armory.Squadrons.Application.SearchByCode;
using Armory.Users.Application.Authenticate;
using Armory.Users.Application.ChangePassword;
using Armory.Users.Application.ConfirmEmail;
using Armory.Users.Application.Create;
using Armory.Users.Application.GenerateEmailConfirmationToken;
using Armory.Users.Application.GenerateJwt;
using Armory.Users.Application.GeneratePasswordResetToken;
using Armory.Users.Application.ResetPassword;
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
            services.AddCommandServices(AssemblyHelper.GetInstance(Assemblies.Armory));
            services.AddQueryServices(AssemblyHelper.GetInstance(Assemblies.Armory));

            services.AddScoped<SquadronCreator, SquadronCreator>();
            services.AddScoped<SquadronByCodeSearcher, SquadronByCodeSearcher>();
            services.AddScoped<SquadronsSearcher, SquadronsSearcher>();

            return services;
        }
    }
}
