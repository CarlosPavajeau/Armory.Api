using System.Threading.Tasks;
using Armory.Squadron.Domain;

namespace Armory.Squadron.Application.Create
{
    public class SquadronCreator
    {
        private readonly ISquadronRepository _repository;

        public SquadronCreator(ISquadronRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(string code, string name, string armoryUserId)
        {
            var squadron = Domain.Squadron.Create(code, name, armoryUserId);

            await _repository.Save(squadron);
        }
    }
}
