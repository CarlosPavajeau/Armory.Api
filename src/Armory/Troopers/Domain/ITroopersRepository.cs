using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Troopers.Domain
{
    public interface ITroopersRepository
    {
        Task Save(Troop troop);
        Task<Troop> Find(string id, bool noTracking = true);
        Task<IEnumerable<Troop>> SearchAll(bool noTracking = true);
        Task<IEnumerable<Troop>> SearchAllBySquad(string squadCode, bool noTracking = true);
        Task<bool> Any(Expression<Func<Troop, bool>> predicate);
        Task Update(Troop newTroop);
    }
}
