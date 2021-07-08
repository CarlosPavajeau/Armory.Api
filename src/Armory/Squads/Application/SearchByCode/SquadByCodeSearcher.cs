using System.Threading.Tasks;
using Armory.Squads.Domain;

namespace Armory.Squads.Application.SearchByCode
{
    public class SquadByCodeSearcher
    {
        private readonly ISquadRepository _repository;

        public SquadByCodeSearcher(ISquadRepository repository)
        {
            _repository = repository;
        }

        public async Task<SquadResponse> Search(string code)
        {
            var squad = await _repository.Find(code);
            return squad == null ? null : SquadResponse.FromAggregate(squad);
        }
    }
}
