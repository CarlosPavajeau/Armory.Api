using Armory.Ranks.Application.Create;
using Armory.Ranks.Application.Find;
using Armory.Ranks.Application.SearchAll;
using Armory.Ranks.Application.Update;
using Microsoft.Extensions.DependencyInjection;

namespace Armory.Api.Extensions.DependencyInjection.Ranks
{
    public static class RanksApplication
    {
        public static IServiceCollection AddRanksApplication(this IServiceCollection services)
        {
            services.AddScoped<RankCreator, RankCreator>();
            services.AddScoped<RankFinder, RankFinder>();
            services.AddScoped<AllRanksSearcher, AllRanksSearcher>();
            services.AddScoped<RankUpdater, RankUpdater>();

            return services;
        }
    }
}
