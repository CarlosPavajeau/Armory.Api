using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Flights.Application.SearchAll
{
    public class SearchAllFlightsQuery : Query<IEnumerable<FlightResponse>>
    {
    }
}
