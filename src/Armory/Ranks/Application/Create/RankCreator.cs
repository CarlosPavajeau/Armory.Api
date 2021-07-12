using System.Threading.Tasks;
using Armory.Ranks.Domain;

namespace Armory.Ranks.Application.Create
{
    public class RankCreator
    {
        private readonly IRanksRepository _repository;

        public RankCreator(IRanksRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(string name)
        {
            var rank = Rank.Create(name);
            await _repository.Save(rank);
        }
    }
}
