using System.Collections.Generic;
using System.Threading.Tasks;

namespace Armory.Armament.Equipments.Domain
{
    public interface IEquipmentsRepository
    {
        Task Save(Equipment equipment);
        Task<Equipment> Find(string code);
        Task<IEnumerable<Equipment>> SearchAll();
        Task Update(Equipment newEquipment);
    }
}
