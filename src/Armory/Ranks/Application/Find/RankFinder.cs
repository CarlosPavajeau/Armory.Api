using System.Threading.Tasks;
using Armory.Ranks.Domain;

namespace Armory.Ranks.Application.Find
{
    public class RankFinder
    {
        private readonly IRanksRepository _repository;

        public RankFinder(IRanksRepository repository)
        {
            _repository = repository;
        }

        public async Task<Rank> Find(int id, bool noTracking)
        {
            return await _repository.Find(id, noTracking);
        }

        public async Task<Rank> Find(int id)
        {
            return await Find(id, true).ConfigureAwait(false);
        }
    }
}
