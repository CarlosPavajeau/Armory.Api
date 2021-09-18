using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Squads.Domain;
using Microsoft.EntityFrameworkCore;

namespace Armory.Squads.Infrastructure.Persistence
{
    public class MySqlSquadsRepository : ISquadsRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlSquadsRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Squad squad)
        {
            await _context.Squads.AddAsync(squad);
            await _context.SaveChangesAsync();
        }

        public async Task<Squad> Find(string code, bool noTracking)
        {
            var query = noTracking ? _context.Squads.AsNoTracking() : _context.Squads.AsTracking();

            return await query
                .Include(s => s.Owner)
                .Include(s => s.Flight)
                .FirstOrDefaultAsync(s => s.Code == code);
        }

        public async Task<Squad> Find(string code)
        {
            return await Find(code, true);
        }

        public async Task<bool> Any(Expression<Func<Squad, bool>> predicate)
        {
            return await _context.Squads.AnyAsync(predicate);
        }

        public async Task<IEnumerable<Squad>> SearchAll(bool noTracking)
        {
            var query = noTracking ? _context.Squads.AsNoTracking() : _context.Squads.AsTracking();

            return await query
                .Include(s => s.Owner)
                .Include(s => s.Flight)
                .ToListAsync();
        }

        public async Task<IEnumerable<Squad>> SearchAll()
        {
            return await SearchAll(true);
        }

        public async Task<IEnumerable<Squad>> SearchAllByFlight(string flightCode, bool noTracking)
        {
            var query = noTracking ? _context.Squads.AsNoTracking() : _context.Squads.AsTracking();

            return await query.Where(s => s.FlightCode == flightCode).ToListAsync();
        }

        public async Task<IEnumerable<Squad>> SearchAllByFlight(string flightCode)
        {
            return await SearchAllByFlight(flightCode, true);
        }
    }
}
