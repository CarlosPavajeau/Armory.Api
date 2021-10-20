using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Repositories;

namespace Armory.Armament.Weapons.Domain
{
    public interface IWeaponsRepository : IRepository<Weapon, string>
    {
        Task<IEnumerable<Weapon>> SearchAllByFlight(string flightCode);
        Task Update(Weapon newWeapon);
    }
}
