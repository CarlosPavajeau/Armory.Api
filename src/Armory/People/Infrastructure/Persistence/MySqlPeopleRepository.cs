using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.People.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Repositories;
using Armory.Users.Domain;
using Microsoft.EntityFrameworkCore;

namespace Armory.People.Infrastructure.Persistence
{
    public class MySqlPeopleRepository : Repository<Person, string>, IPeopleRepository
    {
        private readonly IArmoryUsersRepository _armoryUsersRepository;

        public MySqlPeopleRepository(ArmoryDbContext context, IArmoryUsersRepository armoryUsersRepository) :
            base(context)
        {
            _armoryUsersRepository = armoryUsersRepository;
        }

        public override async Task<Person> Find(string personId, bool noTracking)
        {
            var query = noTracking ? Context.People.AsNoTracking() : Context.People.AsTracking();

            return await query
                .Include(p => p.Degree)
                .ThenInclude(d => d.Rank)
                .FirstOrDefaultAsync(p => p.Id == personId);
        }

        public override async Task<Person> Find(string personId)
        {
            return await Find(personId, true);
        }

        public async Task<Person> FindByArmoryUserId(string armoryUserId)
        {
            return await Context.People
                .AsNoTracking()
                .Include(p => p.Degree)
                .ThenInclude(d => d.Rank)
                .FirstOrDefaultAsync(p => p.ArmoryUserId == armoryUserId);
        }

        public override async Task<IEnumerable<Person>> SearchAll()
        {
            return await Context.People
                .AsNoTracking()
                .Include(p => p.Degree)
                .ThenInclude(d => d.Rank)
                .OrderBy(p => p.LastName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Person>> SearchAllByRole(string roleName)
        {
            var usersInRole = await _armoryUsersRepository.SearchAllUsersInRole(roleName);
            var userIds = usersInRole.Select(u => u.Id);

            return await Context.People
                .AsNoTracking()
                .Where(p => userIds.Contains(p.ArmoryUserId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Person>> SearchAllByRank(string rankName)
        {
            return await Context.People
                .AsNoTracking()
                .Include(p => p.Degree)
                .ThenInclude(d => d.Rank)
                .Where(p => p.Degree.Rank.Name == rankName)
                .ToListAsync();
        }

        public async Task Update(Person newPerson)
        {
            Context.People.Update(newPerson);
            await Context.SaveChangesAsync();
        }
    }
}
