using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.CheckExists
{
    public class PersonExistsChecker
    {
        private readonly IPersonRepository _repository;

        public PersonExistsChecker(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(string id)
        {
            return await _repository.Any(p => p.Id == id);
        }
    }
}
