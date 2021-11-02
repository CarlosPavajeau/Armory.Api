using Armory.Troopers.Application.CheckExists;
using Armory.Troopers.Application.Create;
using Armory.Troopers.Application.Find;
using Armory.Troopers.Application.SearchAll;
using Armory.Troopers.Application.SearchAllByFireteam;
using Armory.Troopers.Application.Update;
using Armory.Troopers.Application.UpdateFireTeam;
using Microsoft.Extensions.DependencyInjection;

namespace Armory.Api.Extensions.DependencyInjection.Troopers
{
    public static class TroopersApplication
    {
        public static IServiceCollection AddTroopersApplication(this IServiceCollection services)
        {
            services.AddScoped<TroopCreator, TroopCreator>();
            services.AddScoped<TroopFinder, TroopFinder>();
            services.AddScoped<TroopExistsChecker, TroopExistsChecker>();
            services.AddScoped<AllTroopsSearcher, AllTroopsSearcher>();
            services.AddScoped<TroopersByFireteamSearcher, TroopersByFireteamSearcher>();
            services.AddScoped<TroopUpdater, TroopUpdater>();
            services.AddScoped<TroopFireTeamUpdater, TroopFireTeamUpdater>();

            return services;
        }
    }
}
