using System.Collections.Generic;
using System.Threading.Tasks;

namespace Armory.Squads.Domain
{
    public interface ISquadRepository
    {
        Task Save(Squad squad);
        Task<Squad> Find(string code);
        Task<IEnumerable<Squad>> SearchAll();
    }
}
