using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Troopers.Domain;
using Microsoft.EntityFrameworkCore;

namespace Armory.Troopers.Infrastructure.Persistence
{
    public class MySqlTroopersRepository : ITroopersRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlTroopersRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Troop troop)
        {
            await _context.Troopers.AddAsync(troop);
            await _context.SaveChangesAsync();
        }

        public async Task<Troop> Find(string id, bool noTracking)
        {
            var query = noTracking ? _context.Troopers.AsNoTracking() : _context.Troopers.AsTracking();

            return await query
                .Include(t => t.Squad)
                .Include(t => t.Degree)
                .ThenInclude(d => d.Rank)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Troop> Find(string id)
        {
            return await Find(id, true);
        }

        public async Task<IEnumerable<Troop>> SearchAll(bool noTracking)
        {
            var query = noTracking ? _context.Troopers.AsNoTracking() : _context.Troopers.AsTracking();

            return await query
                .Include(t => t.Squad)
                .Include(t => t.Degree)
                .ThenInclude(d => d.Rank)
                .OrderBy(t => t.LastName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Troop>> SearchAll()
        {
            return await SearchAll(true);
        }

        public async Task<IEnumerable<Troop>> SearchAllBySquad(string squadCode, bool noTracking)
        {
            var query = noTracking ? _context.Troopers.AsNoTracking() : _context.Troopers.AsTracking();
            return await query.Where(t => t.SquadCode == squadCode).ToListAsync();
        }

        public async Task<IEnumerable<Troop>> SearchAllBySquad(string squadCode)
        {
            return await SearchAllBySquad(squadCode, true);
        }

        public async Task<bool> Any(Expression<Func<Troop, bool>> predicate)
        {
            return await _context.Troopers.AnyAsync(predicate);
        }

        public async Task Update(Troop newTroop)
        {
            _context.Troopers.Update(newTroop);
            await _context.SaveChangesAsync();
        }
    }
}
