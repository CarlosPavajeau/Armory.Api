using System.Collections.Generic;
using System.Threading.Tasks;

namespace Armory.Troopers.Domain
{
    public interface ITroopersRepository
    {
        Task Save(Troop troop);
        Task<Troop> Find(string id);
        Task<IEnumerable<Troop>> SearchAll();
        Task Update(Troop newTroop);
    }
}
