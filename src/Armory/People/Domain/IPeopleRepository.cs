using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.People.Domain
{
    public interface IPeopleRepository
    {
        Task Save(Person person);

        Task<Person> Find(string personId, bool noTracking = true);
        Task<Person> FindByArmoryUserId(string armoryUserId, bool noTracking = true);

        Task<IEnumerable<Person>> SearchAll(bool noTracking = true);
        Task<IEnumerable<Person>> SearchAllByRole(string roleName, bool noTracking = true);
        Task<bool> Any(Expression<Func<Person, bool>> predicate);

        Task Update(Person newPerson);
        Task Delete(Person person);
    }
}
