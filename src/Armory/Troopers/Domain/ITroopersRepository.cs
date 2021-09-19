using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Troopers.Domain
{
    public interface ITroopersRepository
    {
        Task Save(Troop troop);
        Task<Troop> Find(string id, bool noTracking);
        Task<Troop> Find(string id);
        Task<IEnumerable<Troop>> SearchAll(bool noTracking);
        Task<IEnumerable<Troop>> SearchAll();
        Task<IEnumerable<Troop>> SearchAllByFireteam(string fireteamCode, bool noTracking);
        Task<IEnumerable<Troop>> SearchAllByFireteam(string fireteamCode);
        Task<bool> Any(Expression<Func<Troop, bool>> predicate);
        Task Update(Troop newTroop);
    }
}
