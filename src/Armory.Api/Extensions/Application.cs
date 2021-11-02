using Armory.Api.Extensions.DependencyInjection.Armament;
using Armory.Api.Extensions.DependencyInjection.Degrees;
using Armory.Api.Extensions.DependencyInjection.FireTeams;
using Armory.Api.Extensions.DependencyInjection.Flights;
using Armory.Api.Extensions.DependencyInjection.Formats;
using Armory.Api.Extensions.DependencyInjection.People;
using Armory.Api.Extensions.DependencyInjection.Ranks;
using Armory.Api.Extensions.DependencyInjection.Squads;
using Armory.Api.Extensions.DependencyInjection.Troopers;
using Armory.Api.Extensions.DependencyInjection.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Armory.Api.Extensions
{
    public static class Application
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddArmoryUsersApplication()
                .AddArmamentApplication()
                .AddDegreesApplication()
                .AddFireTeamsApplication()
                .AddFlightsApplication()
                .AddFormatsApplication()
                .AddPeopleApplication()
                .AddRanksApplication()
                .AddSquadsApplication()
                .AddTroopersApplication();

            return services;
        }
    }
}
