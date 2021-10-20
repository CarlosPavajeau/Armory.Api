using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Repositories;

namespace Armory.People.Domain
{
    public interface IPeopleRepository : IRepository<Person, string>
    {
        Task<Person> FindByArmoryUserId(string armoryUserId);

        Task<IEnumerable<Person>> SearchAllByRole(string roleName);
        Task<IEnumerable<Person>> SearchAllByRank(string rankName);

        Task Update(Person newPerson);
    }
}
