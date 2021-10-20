using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Repositories;

namespace Armory.Armament.Explosives.Domain
{
    public interface IExplosivesRepository : IRepository<Explosive, string>
    {
        Task<IEnumerable<Explosive>> SearchAllByFlight(string flightCode);
        Task Update(Explosive newExplosive);
    }
}
