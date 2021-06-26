using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.Create
{
    public class PersonCreator
    {
        private readonly IPersonRepository _repository;

        public PersonCreator(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(string id, string firstName, string secondName, string lastName, string secondLastName,
            string armoryUserId)
        {
            var person = Person.Create(id, firstName, secondName, lastName, secondLastName, armoryUserId);
            await _repository.Save(person);
        }
    }
}
