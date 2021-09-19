using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Fireteams.Application.SearchAllByFlight
{
    public class SearchAllFireteamsByFlightQuery : Query<IEnumerable<FireteamResponse>>
    {
        public SearchAllFireteamsByFlightQuery(string flightCode)
        {
            FlightCode = flightCode;
        }

        public string FlightCode { get; }
    }
}
