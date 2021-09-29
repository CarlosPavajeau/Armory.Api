using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Armament.Equipments.Domain
{
    public interface IEquipmentsRepository
    {
        Task Save(Equipment equipment);
        Task<Equipment> Find(string series, bool noTracking);
        Task<Equipment> Find(string series);
        Task<IEnumerable<Equipment>> SearchAll(bool noTracking);
        Task<IEnumerable<Equipment>> SearchAll();
        Task<IEnumerable<Equipment>> SearchAllByFlight(string flightCode);
        Task<bool> Any(Expression<Func<Equipment, bool>> predicate);
        Task Update(Equipment newEquipment);
    }
}
