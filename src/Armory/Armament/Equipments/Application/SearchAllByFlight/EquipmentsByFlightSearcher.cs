using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Armament.Equipments.Domain;

namespace Armory.Armament.Equipments.Application.SearchAllByFlight
{
    public class EquipmentsByFlightSearcher
    {
        private readonly IEquipmentsRepository _repository;

        public EquipmentsByFlightSearcher(IEquipmentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Equipment>> SearchAllByFlight(string flightCode)
        {
            return await _repository.SearchAllByFlight(flightCode);
        }
    }
}
