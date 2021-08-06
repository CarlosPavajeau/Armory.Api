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

        public UpdateAmmunitionCommandHandler(AmmunitionUpdater updater, AmmunitionFinder finder)
        {
            _updater = updater;
            _finder = finder;
        }

        protected override async Task Handle(UpdateAmmunitionCommand request, CancellationToken cancellationToken)
        {
            var ammunition = await _finder.Find(request.Code);
            if (ammunition == null) throw new AmmunitionNotFound();

            await _updater.Update(ammunition, request.Type, request.Mark, request.Caliber, request.Series,
                request.Lot, request.QuantityAvailable);
        }
    }
}
