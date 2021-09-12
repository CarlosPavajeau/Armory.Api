using System.Collections.Generic;
using System.Threading.Tasks;

namespace Armory.Degrees.Domain
{
    public interface IDegreesRepository
    {
        Task Save(Degree degree);
        Task<Degree> Find(int id, bool noTracking);
        Task<Degree> Find(int id);
        Task<IEnumerable<Degree>> SearchAll(bool noTracking);
        Task<IEnumerable<Degree>> SearchAll();
        Task<IEnumerable<Degree>> SearchAllByRank(int rankId, bool noTracking);
        Task<IEnumerable<Degree>> SearchAllByRank(int rankId);
    }
}
