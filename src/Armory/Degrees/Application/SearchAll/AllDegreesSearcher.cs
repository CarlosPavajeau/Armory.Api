using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<DegreeResponse>> SearchAll()
        {
            var degrees = await _repository.SearchAll();
            return degrees.Select(DegreeResponse.FromAggregate);
        }
    }
}
