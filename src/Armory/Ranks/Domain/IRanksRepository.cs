using System.Collections.Generic;
using System.Threading.Tasks;

namespace Armory.Ranks.Domain
{
    public interface IRanksRepository
    {
        Task Save(Rank rank);
        Task<Rank> Find(int id, bool noTracking = true);
        Task<IEnumerable<Rank>> SearchAll(bool noTracking = true);
    }
}
