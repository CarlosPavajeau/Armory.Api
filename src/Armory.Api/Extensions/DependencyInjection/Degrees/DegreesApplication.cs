using Armory.Degrees.Application.Create;
using Armory.Degrees.Application.Find;
using Armory.Degrees.Application.SearchAll;
using Armory.Degrees.Application.SearchAllByRank;
using Armory.Degrees.Application.Update;
using Microsoft.Extensions.DependencyInjection;

namespace Armory.Api.Extensions.DependencyInjection.Degrees
{
    public static class DegreesApplication
    {
        public static IServiceCollection AddDegreesApplication(this IServiceCollection services)
        {
            services.AddScoped<DegreeCreator, DegreeCreator>();
            services.AddScoped<DegreeFinder, DegreeFinder>();
            services.AddScoped<AllDegreesSearcher, AllDegreesSearcher>();
            services.AddScoped<DegreesByRankSearcher, DegreesByRankSearcher>();
            services.AddScoped<DegreeUpdater, DegreeUpdater>();

            return services;
        }
    }
}
