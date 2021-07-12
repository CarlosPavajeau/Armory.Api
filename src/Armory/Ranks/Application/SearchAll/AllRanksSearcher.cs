using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Ranks.Domain;

namespace Armory.Ranks.Application.SearchAll
{
    public class AllRanksSearcher
    {
        private readonly IRanksRepository _repository;

        public AllRanksSearcher(IRanksRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RankResponse>> SearchAll()
        {
            var ranks = await _repository.SearchAll();
            return ranks.Select(RankResponse.FromAggregate);
        }
    }
}
