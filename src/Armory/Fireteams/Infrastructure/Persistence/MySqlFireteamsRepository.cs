using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Armory.Fireteams.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Fireteams.Infrastructure.Persistence
{
    public class MySqlFireteamsRepository : IFireteamsRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlFireteamsRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Fireteam fireteam)
        {
            await _context.Fireteams.AddAsync(fireteam);
            await _context.SaveChangesAsync();
        }

        public async Task<Fireteam> Find(string code, bool noTracking)
        {
            var query = noTracking ? _context.Fireteams.AsNoTracking() : _context.Fireteams.AsTracking();

            return await query
                .Include(s => s.Owner)
                .ThenInclude(o => o.Degree)
                .ThenInclude(d => d.Rank)
                .Include(s => s.Flight)
                .FirstOrDefaultAsync(s => s.Code == code);
        }

        public async Task<Fireteam> Find(string code)
        {
            return await Find(code, true);
        }

        public async Task<bool> Any(Expression<Func<Fireteam, bool>> predicate)
        {
            return await _context.Fireteams.AnyAsync(predicate);
        }

        public async Task<IEnumerable<Fireteam>> SearchAll(bool noTracking)
        {
            var query = noTracking ? _context.Fireteams.AsNoTracking() : _context.Fireteams.AsTracking();

            return await query
                .Include(s => s.Owner)
                .ThenInclude(o => o.Degree)
                .Include(s => s.Flight)
                .ToListAsync();
        }

        public async Task<IEnumerable<Fireteam>> SearchAll()
        {
            return await SearchAll(true);
        }

        public async Task<IEnumerable<Fireteam>> SearchAllByFlight(string flightCode, bool noTracking)
        {
            var query = noTracking ? _context.Fireteams.AsNoTracking() : _context.Fireteams.AsTracking();

            return await query.Where(s => s.FlightCode == flightCode).ToListAsync();
        }

        public async Task<IEnumerable<Fireteam>> SearchAllByFlight(string flightCode)
        {
            return await SearchAllByFlight(flightCode, true);
        }
    }
}
