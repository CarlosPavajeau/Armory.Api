using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Repositories;

namespace Armory.Armament.Ammunition.Domain
{
    public interface IAmmunitionRepository : IRepository<Ammunition, string>
    {
        Task<IEnumerable<Ammunition>> SearchAllByFlight(string flightCode);
        Task Update(Ammunition newAmmunition);
    }
}
