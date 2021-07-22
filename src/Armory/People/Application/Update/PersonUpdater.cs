using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.Update
{
    public class PersonUpdater
    {
        private readonly IPeopleRepository _repository;

        public PersonUpdater(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public async Task Update(Person person, string newFirstName, string newSecondName, string newLastname,
            string newSecondLastName)
        {
            person.Update(newFirstName, newSecondName, newLastname, newSecondLastName);
            await _repository.Update(person);
        }
    }
}
