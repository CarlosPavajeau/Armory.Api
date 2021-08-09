using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Armament.Equipments.Domain
{
    public interface IEquipmentsRepository
    {
        Task Save(Equipment equipment);
        Task<Equipment> Find(string code, bool noTracking = true);
        Task<IEnumerable<Equipment>> SearchAll(bool noTracking = true);
        Task<bool> Any(Expression<Func<Equipment, bool>> predicate);
        Task Update(Equipment newEquipment);
    }
}
