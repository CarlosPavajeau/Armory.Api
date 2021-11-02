using Armory.Fireteams.Application.CheckExists;
using Armory.Fireteams.Application.Create;
using Armory.Fireteams.Application.Find;
using Armory.Fireteams.Application.SearchAll;
using Armory.Fireteams.Application.SearchAllByFlight;
using Armory.Fireteams.Application.UpdateCommander;
using Microsoft.Extensions.DependencyInjection;

namespace Armory.Api.Extensions.DependencyInjection.FireTeams
{
    public static class FireTeamApplication
    {
        public static IServiceCollection AddFireTeamsApplication(this IServiceCollection services)
        {
            services.AddScoped<FireteamCreator, FireteamCreator>();
            services.AddScoped<FireteamFinder, FireteamFinder>();
            services.AddScoped<FireteamExistsChecker, FireteamExistsChecker>();
            services.AddScoped<FireteamsSearcher, FireteamsSearcher>();
            services.AddScoped<FireteamsByFlightSearcher, FireteamsByFlightSearcher>();
            services.AddScoped<FireTeamCommanderUpdater, FireTeamCommanderUpdater>();

            return services;
        }
    }
}
