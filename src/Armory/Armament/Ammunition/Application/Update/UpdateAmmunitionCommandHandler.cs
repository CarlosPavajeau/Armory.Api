using System.Threading.Tasks;
using Armory.Armament.Ammunition.Application.Find;
using Armory.Armament.Ammunition.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Ammunition.Application.Update
{
    public class UpdateAmmunitionCommandHandler : ICommandHandler<UpdateAmmunitionCommand>
    {
        private readonly AmmunitionUpdater _updater;
        private readonly AmmunitionFinder _finder;

        public UpdateAmmunitionCommandHandler(AmmunitionUpdater updater, AmmunitionFinder finder)
        {
            _updater = updater;
            _finder = finder;
        }

        public async Task Handle(UpdateAmmunitionCommand command)
        {
            var ammunition = await _finder.Find(command.Code);
            if (ammunition == null)
            {
                throw new AmmunitionNotFound();
            }

            await _updater.Update(ammunition, command.Type, command.Mark, command.Caliber, command.Series,
                command.Lot, command.QuantityAvailable);
        }
    }
}
