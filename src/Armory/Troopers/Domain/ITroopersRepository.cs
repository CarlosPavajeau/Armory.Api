using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Repositories;

namespace Armory.Troopers.Domain
{
    public interface ITroopersRepository : IRepository<Troop, string>
    {
        Task<IEnumerable<Troop>> SearchAllByFireTeam(string fireTeamCode);

        Task Update(Troop newTroop);
    }
}
