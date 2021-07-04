using System.Collections.Generic;
using System.Threading.Tasks;

namespace Armory.People.Domain
{
    public interface IPersonRepository
    {
        Task Save(Person person);

        Task<Person> Find(string personId);
        Task<Person> FindByArmoryUserId(string armoryUserId);

        Task<IEnumerable<Person>> SearchAll();
        Task<IEnumerable<Person>> SearchAllByRole(string roleName);
        Task<bool> CheckExists(string id);

        Task Update(Person newPerson);
        Task Delete(Person person);
    }
}
