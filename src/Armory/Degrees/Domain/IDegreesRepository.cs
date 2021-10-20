using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Repositories;

namespace Armory.Degrees.Domain
{
    public interface IDegreesRepository : IRepository<Degree, int>
    {
        Task<IEnumerable<Degree>> SearchAllByRank(int rankId);
    }
}
