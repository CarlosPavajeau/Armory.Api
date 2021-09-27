using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Armament.Weapons.Domain
{
    public interface IWeaponsRepository
    {
        Task Save(Weapon weapon);
        Task<Weapon> Find(string series, bool noTracking);
        Task<Weapon> Find(string series);
        Task<IEnumerable<Weapon>> SearchAll(bool noTracking);
        Task<IEnumerable<Weapon>> SearchAll();
        Task<bool> Any(Expression<Func<Weapon, bool>> predicate);
        Task Update(Weapon newWeapon);
    }
}
