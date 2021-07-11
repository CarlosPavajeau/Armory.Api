using System.Collections.Generic;
using System.Threading.Tasks;

namespace Armory.Armament.Explosives.Domain
{
    public interface IExplosivesRepository
    {
        Task Save(Explosive explosive);
        Task<Explosive> Find(string code);
        Task<IEnumerable<Explosive>> SearchAll();
        Task Update(Explosive newExplosive);
    }
}
