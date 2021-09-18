using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Squads.Domain
{
    public interface ISquadsRepository
    {
        Task Save(Squad squad);
        Task<Squad> Find(string code, bool noTracking);
        Task<Squad> Find(string code);
        Task<bool> Any(Expression<Func<Squad, bool>> predicate);
        Task<IEnumerable<Squad>> SearchAll(bool noTracking);
        Task<IEnumerable<Squad>> SearchAll();
        Task<IEnumerable<Squad>> SearchAllByFlight(string flightCode, bool noTracking);
        Task<IEnumerable<Squad>> SearchAllByFlight(string flightCode);
    }
}
