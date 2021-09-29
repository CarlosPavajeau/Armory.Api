using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Equipments.Application.SearchAllByFlight
{
    public class SearchAllEquipmentsByFlightQuery : Query<IEnumerable<EquipmentResponse>>
    {
        public string FlightCode { get; init; }
    }
}
