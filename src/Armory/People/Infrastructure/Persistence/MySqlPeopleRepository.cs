using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Armory.People.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Users.Domain;
using Microsoft.EntityFrameworkCore;

namespace Armory.People.Infrastructure.Persistence
{
    public class MySqlPeopleRepository : IPeopleRepository
    {
        private readonly IArmoryUsersRepository _armoryUsersRepository;
        private readonly ArmoryDbContext _context;

        public MySqlPeopleRepository(ArmoryDbContext context, IArmoryUsersRepository armoryUsersRepository)
        {
            _context = context;
            _armoryUsersRepository = armoryUsersRepository;
        }

        public async Task Save(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task<Person> Find(string personId, bool noTracking = true)
        {
            if (noTracking)
                return await _context.People
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == personId);

            return await _context.People.FindAsync(personId);
        }

        public async Task<Person> FindByArmoryUserId(string armoryUserId, bool noTracking = true)
        {
            if (noTracking)
                return await _context.People
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.ArmoryUserId == armoryUserId);

            return await _context.People.FirstOrDefaultAsync(p => p.ArmoryUserId == armoryUserId);
        }

        public async Task<IEnumerable<Person>> SearchAll(bool noTracking = true)
        {
            if (noTracking)
                return await _context.People
                    .AsNoTracking()
                    .ToListAsync();

            return await _context.People.ToListAsync();
        }

        public async Task<IEnumerable<Person>> SearchAllByRole(string roleName, bool noTracking = true)
        {
            var usersInRole = await _armoryUsersRepository.SearchAllUsersInRole(roleName);
            var userIds = usersInRole.Select(u => u.Id);

            if (noTracking)
                return await _context.People
                    .AsNoTracking()
                    .Where(p => userIds.Contains(p.ArmoryUserId))
                    .ToListAsync();

            return await _context.People
                .Where(p => userIds.Contains(p.ArmoryUserId))
                .ToListAsync();
        }

        public async Task<bool> Any(Expression<Func<Person, bool>> predicate)
        {
            return await _context.People.AnyAsync(predicate);
        }

        public async Task Update(Person newPerson)
        {
            _context.People.Update(newPerson);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Person person)
        {
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
