using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;
using Armory.Troopers.Application.Find;
using Armory.Troopers.Domain;

namespace Armory.Troopers.Application.Update
{
    public class UpdateTroopCommandHandler : ICommandHandler<UpdateTroopCommand>
    {
        private readonly TroopUpdater _updater;
        private readonly TroopFinder _finder;

        public UpdateTroopCommandHandler(TroopUpdater updater, TroopFinder finder)
        {
            _updater = updater;
            _finder = finder;
        }

        public async Task Handle(UpdateTroopCommand command)
        {
            var troop = await _finder.Find(command.Id);
            if (troop == null)
            {
                throw new TroopNotFound();
            }

            await _updater.Update(troop, command.FirstName, command.SecondName, command.LastName,
                command.SecondLastName);
        }
    }
}
