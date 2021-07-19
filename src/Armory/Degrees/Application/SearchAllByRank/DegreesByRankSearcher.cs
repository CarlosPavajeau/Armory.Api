using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Degrees.Domain;

namespace Armory.Degrees.Application.SearchAllByRank
{
    public class DegreesByRankSearcher
    {
        private readonly IDegreesRepository _repository;

        public DegreesByRankSearcher(IDegreesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DegreeResponse>> SearchByRank(int rankId)
        {
            var degrees = await _repository.SearchAllByRank(rankId);
            return degrees.Select(DegreeResponse.FromAggregate);
        }
    }
}
