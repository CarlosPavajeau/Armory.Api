using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Explosives.Application.SearchAllByFlight
{
    public class SearchAllExplosivesByFlightQuery : Query<IEnumerable<ExplosiveResponse>>
    {
        public string FlightCode { get; init; }
    }
}
