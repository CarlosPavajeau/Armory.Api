using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Ammunition.Application.Update
{
    public class UpdateAmmunitionCommandHandler : ICommandHandler<UpdateAmmunitionCommand>
    {
        private readonly AmmunitionUpdater _updater;

        public UpdateAmmunitionCommandHandler(AmmunitionUpdater updater)
        {
            _updater = updater;
        }

        public async Task Handle(UpdateAmmunitionCommand command)
        {
            await _updater.Update(command.Code, command.Type, command.Mark, command.Caliber, command.Series,
                command.Lot, command.QuantityAvailable);
        }
    }
}
