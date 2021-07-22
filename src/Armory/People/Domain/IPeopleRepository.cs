using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.People.Domain
{
    public interface IPeopleRepository
    {
        Task Save(Person person);

        Task<Person> Find(string personId);
        Task<Person> FindByArmoryUserId(string armoryUserId);

        Task<IEnumerable<Person>> SearchAll();
        Task<IEnumerable<Person>> SearchAllByRole(string roleName);
        Task<bool> Any(Expression<Func<Person, bool>> predicate);

        Task Update(Person newPerson);
        Task Delete(Person person);
    }
}
