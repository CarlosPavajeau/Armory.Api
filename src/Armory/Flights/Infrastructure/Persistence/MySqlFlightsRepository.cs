using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Armory.Flights.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Flights.Infrastructure.Persistence
{
    public class MySqlFlightsRepository : IFlightsRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlFlightsRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Flight flight)
        {
            await _context.Flights.AddAsync(flight);
            await _context.SaveChangesAsync();
        }

        public async Task<Flight> Find(string code, bool noTracking)
        {
            var query = noTracking ? _context.Flights.AsNoTracking() : _context.Flights.AsTracking();

            return await query
                .Include(s => s.Owner)
                .FirstOrDefaultAsync(s => s.Code == code);
        }

        public async Task<Flight> Find(string code)
        {
            return await Find(code, true);
        }

        public async Task<bool> Any(Expression<Func<Flight, bool>> predicate)
        {
            return await _context.Flights.AnyAsync(predicate);
        }

        public async Task<IEnumerable<Flight>> SearchAll(bool noTracking)
        {
            var query = noTracking ? _context.Flights.AsNoTracking() : _context.Flights.AsTracking();

            return await query
                .Include(s => s.Owner)
                .ToListAsync();
        }

        public async Task<IEnumerable<Flight>> SearchAll()
        {
            return await SearchAll(true);
        }
    }
}
