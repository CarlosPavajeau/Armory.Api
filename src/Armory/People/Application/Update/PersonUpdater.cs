using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.Update
{
    public class PersonUpdater
    {
        private readonly IPersonRepository _repository;

        public PersonUpdater(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task Update(string id, string newFirstName, string newSecondName, string newLastname,
            string newSecondLastName)
        {
            var person = await _repository.Find(id);
            if (person == null)
            {
                throw new PersonNotFound();
            }

            person.Update(newFirstName, newSecondName, newLastname, newSecondLastName);
            await _repository.Update(person);
        }
    }
}
