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

        public async Task<Person> Find(string personId, bool noTracking)
        {
            var query = noTracking ? _context.People.AsNoTracking() : _context.People.AsTracking();

            return await query.FirstOrDefaultAsync(p => p.Id == personId);
        }

        public async Task<Person> Find(string personId)
        {
            return await Find(personId, true);
        }

        public async Task<Person> FindByArmoryUserId(string armoryUserId, bool noTracking)
        {
            var query = noTracking ? _context.People.AsNoTracking() : _context.People.AsTracking();

            return await query.FirstOrDefaultAsync(p => p.ArmoryUserId == armoryUserId);
        }

        public async Task<Person> FindByArmoryUserId(string armoryUserId)
        {
            return await FindByArmoryUserId(armoryUserId, true);
        }

        public async Task<IEnumerable<Person>> SearchAll(bool noTracking)
        {
            var query = noTracking ? _context.People.AsNoTracking() : _context.People.AsTracking();

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Person>> SearchAll()
        {
            return await SearchAll(true);
        }

        public async Task<IEnumerable<Person>> SearchAllByRole(string roleName, bool noTracking)
        {
            var usersInRole = await _armoryUsersRepository.SearchAllUsersInRole(roleName);
            var userIds = usersInRole.Select(u => u.Id);

            var query = noTracking ? _context.People.AsNoTracking() : _context.People.AsTracking();

            return await query
                .Where(p => userIds.Contains(p.ArmoryUserId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Person>> SearchAllByRole(string roleName)
        {
            return await SearchAllByRole(roleName, true);
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
