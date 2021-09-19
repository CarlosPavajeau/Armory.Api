using System.Threading.Tasks;
using Armory.Squads.Domain;

namespace Armory.Squads.Application.Find
{
    public class SquadFinder
    {
        private readonly ISquadsRepository _repository;

        public SquadFinder(ISquadsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Squad> Find(string code, bool noTracking)
        {
            return await _repository.Find(code, noTracking);
        }

        public async Task<Squad> Find(string code)
        {
            return await Find(code, true).ConfigureAwait(false);
        }
    }
}
