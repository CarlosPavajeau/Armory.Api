using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Armament.Explosives.Domain
{
    public interface IExplosivesRepository
    {
        Task Save(Explosive explosive);
        Task<Explosive> Find(string serial, bool noTracking);
        Task<Explosive> Find(string serial);
        Task<IEnumerable<Explosive>> SearchAll(bool noTracking);
        Task<IEnumerable<Explosive>> SearchAll();
        Task<bool> Any(Expression<Func<Explosive, bool>> predicate);
        Task Update(Explosive newExplosive);
    }
}
