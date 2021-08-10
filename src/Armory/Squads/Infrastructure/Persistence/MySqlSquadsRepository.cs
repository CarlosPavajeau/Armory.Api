using System;
using System.Collections.Generic;
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

        public async Task<Squad> Find(string code, bool noTracking = true)
        {
            if (noTracking)
            {
                return await _context.Squads
                    .AsNoTracking()
                    .FirstOrDefaultAsync(s => s.Code == code);
            }

            return await _context.Squads.FindAsync(code);
        }

        public async Task<bool> Any(Expression<Func<Squad, bool>> predicate)
        {
            return await _context.Squads.AnyAsync(predicate);
        }

        public async Task<IEnumerable<Squad>> SearchAll(bool noTracking = true)
        {
            if (noTracking)
            {
                return await _context.Squads
                    .AsNoTracking()
                    .ToListAsync();
            }

            return await _context.Squads.ToListAsync();
        }
    }
}
