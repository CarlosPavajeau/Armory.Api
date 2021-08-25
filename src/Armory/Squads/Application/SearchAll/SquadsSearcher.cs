using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Squads.Domain;

namespace Armory.Squads.Application.SearchAll
{
    public class SquadsSearcher
    {
        private readonly ISquadsRepository _repository;

        public SquadsSearcher(ISquadsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Squad>> SearchAll()
        {
            return await _repository.SearchAll();
        }
    }
}
