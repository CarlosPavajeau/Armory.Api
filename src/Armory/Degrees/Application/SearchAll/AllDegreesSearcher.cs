using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Degrees.Domain;

namespace Armory.Degrees.Application.SearchAll
{
    public class AllDegreesSearcher
    {
        private readonly IDegreesRepository _repository;

        public AllDegreesSearcher(IDegreesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Degree>> SearchAll()
        {
            return await _repository.SearchAll();
        }
    }
}
