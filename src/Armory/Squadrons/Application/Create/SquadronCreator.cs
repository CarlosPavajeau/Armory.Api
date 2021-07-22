using System.Threading.Tasks;
using Armory.Squadrons.Domain;

namespace Armory.Squadrons.Application.Create
{
    public class SquadronCreator
    {
        private readonly ISquadronsRepository _repository;

        public SquadronCreator(ISquadronsRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(string code, string name, string armoryUserId)
        {
            var squadron = Squadron.Create(code, name, armoryUserId);

            await _repository.Save(squadron);
        }
    }
}
