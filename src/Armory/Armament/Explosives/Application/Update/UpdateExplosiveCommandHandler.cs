using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Explosives.Application.Update
{
    public class UpdateExplosiveCommandHandler : ICommandHandler<UpdateExplosiveCommand>
    {
        private readonly ExplosiveUpdater _updater;

        public UpdateExplosiveCommandHandler(ExplosiveUpdater updater)
        {
            _updater = updater;
        }

        public async Task Handle(UpdateExplosiveCommand command)
        {
            await _updater.Update(command.Code, command.Type, command.Caliber, command.Mark, command.Lot,
                command.Series, command.QuantityAvailable);
        }
    }
}
