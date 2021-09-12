using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Armament.Ammunition.Domain
{
    public interface IAmmunitionRepository
    {
        Task Save(Ammunition ammunition);
        Task<Ammunition> Find(string code, bool noTracking);
        Task<Ammunition> Find(string code);
        Task<IEnumerable<Ammunition>> SearchAll(bool noTracking);
        Task<IEnumerable<Ammunition>> SearchAll();
        Task<bool> Any(Expression<Func<Ammunition, bool>> predicate);
        Task Update(Ammunition newAmmunition);
    }
}
