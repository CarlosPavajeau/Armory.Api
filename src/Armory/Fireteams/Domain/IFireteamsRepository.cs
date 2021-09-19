using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Fireteams.Domain
{
    public interface IFireteamsRepository
    {
        Task Save(Fireteam fireteam);
        Task<Fireteam> Find(string code, bool noTracking);
        Task<Fireteam> Find(string code);
        Task<bool> Any(Expression<Func<Fireteam, bool>> predicate);
        Task<IEnumerable<Fireteam>> SearchAll(bool noTracking);
        Task<IEnumerable<Fireteam>> SearchAll();
        Task<IEnumerable<Fireteam>> SearchAllByFlight(string flightCode, bool noTracking);
        Task<IEnumerable<Fireteam>> SearchAllByFlight(string flightCode);
    }
}
