using System.Threading.Tasks;
using Armory.Degrees.Domain;

namespace Armory.Degrees.Application.Find
{
    public class DegreeFinder
    {
        private readonly IDegreesRepository _repository;

        public DegreeFinder(IDegreesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Degree> Find(int id)
        {
            return await _repository.Find(id);
        }
    }
}
