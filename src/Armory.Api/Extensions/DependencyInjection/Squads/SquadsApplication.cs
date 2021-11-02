using Armory.Squads.Application.CheckExists;
using Armory.Squads.Application.Create;
using Armory.Squads.Application.Find;
using Armory.Squads.Application.SearchAll;
using Armory.Squads.Application.UpdateCommander;
using Microsoft.Extensions.DependencyInjection;

namespace Armory.Api.Extensions.DependencyInjection.Squads
{
    public static class SquadsApplication
    {
        public static IServiceCollection AddSquadsApplication(this IServiceCollection services)
        {
            services.AddScoped<SquadCreator, SquadCreator>();
            services.AddScoped<SquadExistsChecker, SquadExistsChecker>();
            services.AddScoped<SquadFinder, SquadFinder>();
            services.AddScoped<SquadsSearcher, SquadsSearcher>();
            services.AddScoped<SquadCommanderUpdater, SquadCommanderUpdater>();

            return services;
        }
    }
}
