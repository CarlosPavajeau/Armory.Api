using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Flights.Domain
{
    public interface IFlightsRepository
    {
        Task Save(Flight flight);
        Task<Flight> Find(string code, bool noTracking);
        Task<Flight> Find(string code);
        Task<bool> Any(Expression<Func<Flight, bool>> predicate);
        Task<IEnumerable<Flight>> SearchAll(bool noTracking);
        Task<IEnumerable<Flight>> SearchAll();
    }
}
