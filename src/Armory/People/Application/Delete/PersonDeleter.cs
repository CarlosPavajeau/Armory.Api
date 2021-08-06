using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.Delete
{
    public class PersonDeleter
    {
        private readonly IPeopleRepository _repository;

        public PersonDeleter(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public async Task Delete(string id)
        {
            var person = await _repository.Find(id);
            if (person == null) throw new PersonNotFound();

            await _repository.Delete(person);
        }
    }
}
