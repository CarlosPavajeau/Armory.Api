using System.Threading.Tasks;
using Armory.Armament.Explosives.Application.Find;
using Armory.Armament.Explosives.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Explosives.Application.Update
{
    public class UpdateExplosiveCommandHandler : ICommandHandler<UpdateExplosiveCommand>
    {
        private readonly ExplosiveUpdater _updater;
        private readonly ExplosiveFinder _finder;

        public UpdateExplosiveCommandHandler(ExplosiveUpdater updater, ExplosiveFinder finder)
        {
            _updater = updater;
            _finder = finder;
        }

        public async Task Handle(UpdateExplosiveCommand command)
        {
            var explosive = await _finder.Find(command.Code);
            if (explosive == null)
            {
                throw new ExplosiveNotFound();
            }

            await _updater.Update(explosive, command.Type, command.Caliber, command.Mark, command.Lot,
                command.Series, command.QuantityAvailable);
        }
    }
}
