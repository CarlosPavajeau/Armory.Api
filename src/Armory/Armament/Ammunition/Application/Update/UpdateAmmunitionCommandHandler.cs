using System.Threading;
using System.Threading.Tasks;
using Armory.Armament.Ammunition.Application.Find;
using Armory.Armament.Ammunition.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Ammunition.Application.Update
{
    public class UpdateAmmunitionCommandHandler : CommandHandler<UpdateAmmunitionCommand>
    {
        private readonly AmmunitionFinder _finder;
        private readonly AmmunitionUpdater _updater;

        public UpdateAmmunitionCommandHandler(AmmunitionFinder finder, AmmunitionUpdater updater)
        {
            _finder = finder;
            _updater = updater;
        }

        protected override async Task Handle(UpdateAmmunitionCommand request, CancellationToken cancellationToken)
        {
            var ammunition = await _finder.Find(request.Lot, false);
            if (ammunition is null)
            {
                throw new AmmunitionNotFoundException();
            }

            await _updater.Update(ammunition, request);
        }
    }
}
