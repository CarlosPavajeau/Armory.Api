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

        public async Task<Rank> Find(int id)
        {
            return await _repository.Find(id);
        }
    }
}
