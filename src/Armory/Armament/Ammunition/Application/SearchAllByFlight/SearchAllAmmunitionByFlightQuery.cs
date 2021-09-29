using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Ammunition.Application.SearchAllByFlight
{
    public class SearchAllAmmunitionByFlightQuery : Query<IEnumerable<AmmunitionResponse>>
    {
        public string FlightCode { get; init; }
    }
}
