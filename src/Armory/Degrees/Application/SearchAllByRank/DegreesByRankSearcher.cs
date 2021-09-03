using System.Collections.Generic;
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

        public async Task<IEnumerable<Degree>> SearchByRank(int rankId)
        {
            return await _repository.SearchAllByRank(rankId);
        }
    }
}
