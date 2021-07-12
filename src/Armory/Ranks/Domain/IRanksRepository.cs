using System.Collections.Generic;
using System.Threading.Tasks;

namespace Armory.Ranks.Domain
{
    public interface IRanksRepository
    {
        Task Save(Rank rank);
        Task<Rank> Find(int id);
        Task<IEnumerable<Rank>> SearchAll();
    }
}
