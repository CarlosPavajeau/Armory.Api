using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Repositories;

namespace Armory.Armament.Equipments.Domain
{
    public interface IEquipmentsRepository : IRepository<Equipment, string>
    {
        Task<IEnumerable<Equipment>> SearchAllByFlight(string flightCode);
        Task Update(Equipment newEquipment);
    }
}
