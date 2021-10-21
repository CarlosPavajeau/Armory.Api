using Armory.Flights.Domain;

namespace Armory.Test.Flights
{
    public class FlightsInfrastructureTestCase : ArmoryContextInfrastructureTestCase
    {
        protected IFlightsRepository Repository => GetService<IFlightsRepository>();
    }
}
