using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Repositories;

namespace Armory.Fireteams.Domain
{
    public interface IFireteamsRepository : IRepository<Fireteam, string>
    {
        Task<IEnumerable<Fireteam>> SearchAllByFlight(string flightCode);
    }
}
