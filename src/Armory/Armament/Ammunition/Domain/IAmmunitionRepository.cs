using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Armament.Ammunition.Domain
{
    public interface IAmmunitionRepository
    {
        Task Save(Ammunition ammunition);
        Task<Ammunition> Find(string code, bool noTracking = true);
        Task<IEnumerable<Ammunition>> SearchAll(bool noTracking = true);
        Task<bool> Any(Expression<Func<Ammunition, bool>> predicate);
        Task Update(Ammunition newAmmunition);
    }
}
