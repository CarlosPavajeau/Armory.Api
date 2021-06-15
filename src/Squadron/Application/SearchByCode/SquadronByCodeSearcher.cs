using System.Threading.Tasks;
using Armory.Squadron.Domain;

namespace Armory.Squadron.Application.SearchByCode
{
    public class SquadronByCodeSearcher
    {
        private readonly ISquadronRepository _repository;

        public SquadronByCodeSearcher(ISquadronRepository repository)
        {
            _repository = repository;
        }

        public async Task<SquadronResponse> Search(string code)
        {
            var squadron = await _repository.Find(code);
            return squadron == null ? null : SquadronResponse.FromAggregate(squadron);
        }
    }
}
