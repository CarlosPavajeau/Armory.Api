using Armory.Flights.Application.CheckExists;
using Armory.Flights.Application.Create;
using Armory.Flights.Application.Find;
using Armory.Flights.Application.SearchAll;
using Armory.Flights.Application.UpdateCommander;
using Microsoft.Extensions.DependencyInjection;

namespace Armory.Api.Extensions.DependencyInjection.Flights
{
    public static class FlightsApplication
    {
        public static IServiceCollection AddFlightsApplication(this IServiceCollection services)
        {
            services.AddScoped<FlightCreator, FlightCreator>();
            services.AddScoped<FlightFinder, FlightFinder>();
            services.AddScoped<FlightExistsChecker, FlightExistsChecker>();
            services.AddScoped<FlightsSearcher, FlightsSearcher>();
            services.AddScoped<FlightCommanderUpdater, FlightCommanderUpdater>();

            return services;
        }
    }
}
