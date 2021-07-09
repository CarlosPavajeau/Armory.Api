using System.Collections.Generic;
using System.Threading.Tasks;

namespace Armory.Armament.Ammunition.Domain
{
    public interface IAmmunitionRepository
    {
        Task Save(Ammunition ammunition);
        Task<Ammunition> Find(string code);
        Task<IEnumerable<Ammunition>> SearchAll();
        Task Update(Ammunition newAmmunition);
    }
}
