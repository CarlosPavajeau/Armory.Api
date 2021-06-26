using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.Delete
{
    public class PersonDeleter
    {
        private readonly IPersonRepository _repository;

        public PersonDeleter(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task Delete(string id)
        {
            var person = await _repository.Find(id);
            if (person == null)
            {
                throw new PersonNotFound();
            }

            await _repository.Delete(person);
        }
    }
}
