using System.Threading.Tasks;
using Armory.Troopers.Domain;

namespace Armory.Troopers.Application.Update
{
    public class TroopUpdater
    {
        private readonly ITroopersRepository _repository;

        public TroopUpdater(ITroopersRepository repository)
        {
            _repository = repository;
        }

        public async Task Update(Troop troop, string firstName, string secondName, string lastName,
            string secondLastName)
        {
            troop.Update(firstName, secondName, lastName, secondLastName);
            await _repository.Update(troop);
        }
    }
}
