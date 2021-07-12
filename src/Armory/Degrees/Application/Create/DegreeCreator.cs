using System.Threading.Tasks;
using Armory.Degrees.Domain;

namespace Armory.Degrees.Application.Create
{
    public class DegreeCreator
    {
        private readonly IDegreesRepository _repository;

        public DegreeCreator(IDegreesRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(string name, int rankId)
        {
            var degree = Degree.Create(name, rankId);
            await _repository.Save(degree);
        }
    }
}
