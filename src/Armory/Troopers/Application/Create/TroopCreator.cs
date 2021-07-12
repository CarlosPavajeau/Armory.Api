using System.Threading.Tasks;
using Armory.Troopers.Domain;

namespace Armory.Troopers.Application.Create
{
    public class TroopCreator
    {
        private readonly ITroopersRepository _repository;

        public TroopCreator(ITroopersRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(string id, string firstName, string secondName, string lastName, string secondLastName,
            string squadCode, int degreeId)
        {
            var troop = Troop.Create(id, firstName, secondName, lastName, secondLastName, squadCode, degreeId);
            await _repository.Save(troop);
        }
    }
}
