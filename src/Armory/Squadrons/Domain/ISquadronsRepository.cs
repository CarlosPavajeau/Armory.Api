using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Squadrons.Domain
{
    public interface ISquadronsRepository
    {
        Task Save(Squadron squadron);
        Task<Squadron> Find(string code);
        Task<bool> Any(Expression<Func<Squadron, bool>> predicate);
        Task<IEnumerable<Squadron>> SearchAll();
    }
}
