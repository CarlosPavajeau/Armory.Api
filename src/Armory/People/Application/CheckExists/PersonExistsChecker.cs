using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.CheckExists
{
    public class PersonExistsChecker
    {
        private readonly IPeopleRepository _repository;

        public PersonExistsChecker(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(string id)
        {
            return await _repository.Any(p => p.Id == id);
        }
    }
}
