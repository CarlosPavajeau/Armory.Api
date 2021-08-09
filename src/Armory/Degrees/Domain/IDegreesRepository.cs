using System.Collections.Generic;
using System.Threading.Tasks;

namespace Armory.Degrees.Domain
{
    public interface IDegreesRepository
    {
        Task Save(Degree degree);
        Task<Degree> Find(int id, bool noTracking = true);
        Task<IEnumerable<Degree>> SearchAll(bool noTracking = true);
        Task<IEnumerable<Degree>> SearchAllByRank(int rankId, bool noTracking = true);
    }
}
