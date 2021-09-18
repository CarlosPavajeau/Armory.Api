using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.SearchAllByFlight
{
    public class SearchAllSquadsByFlightQuery : Query<IEnumerable<SquadResponse>>
    {
        public SearchAllSquadsByFlightQuery(string flightCode)
        {
            FlightCode = flightCode;
        }

        public string FlightCode { get; }
    }
}
