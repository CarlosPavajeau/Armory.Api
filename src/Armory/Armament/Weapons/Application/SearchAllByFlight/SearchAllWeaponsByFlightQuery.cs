using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.SearchAllByFlight
{
    public class SearchAllWeaponsByFlightQuery : Query<IEnumerable<WeaponResponse>>
    {
        public string FlightCode { get; init; }
    }
}
