using Armory.Shared.Extensions;
using Armory.Shared.Helpers;
using Armory.Users.Application.Authenticate;
using Armory.Users.Application.Create;
using Armory.Users.Application.GenerateJwt;
using Armory.Users.Application.GeneratePasswordResetToken;
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

            services.AddCommandServices(AssemblyHelper.GetInstance(Assemblies.Users));
            services.AddQueryServices(AssemblyHelper.GetInstance(Assemblies.Users));

            return services;
        }
    }
}
