using System.Collections.Generic;
using System.Threading.Tasks;

namespace Armory.Armament.Weapons.Domain
{
    public interface IWeaponsRepository
    {
        Task Save(Weapon weapon);
        Task<Weapon> Find(string code);
        Task<IEnumerable<Weapon>> SearchAll();
        Task Update(Weapon newWeapon);
    }
}
