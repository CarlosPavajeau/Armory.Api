using Armory.Shared.Domain.Bus.Query;

namespace Armory.Flights.Application.Find
{
    public class FindFlightQuery : Query<FlightResponse>
    {
        public FindFlightQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
