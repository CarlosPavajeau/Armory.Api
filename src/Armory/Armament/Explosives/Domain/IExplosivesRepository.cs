using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Armament.Explosives.Domain
{
    public interface IExplosivesRepository
    {
        Task Save(Explosive explosive);
        Task<Explosive> Find(string code, bool noTracking = true);
        Task<IEnumerable<Explosive>> SearchAll(bool noTracking = true);
        Task<bool> Any(Expression<Func<Explosive, bool>> predicate);
        Task Update(Explosive newExplosive);
    }
}
