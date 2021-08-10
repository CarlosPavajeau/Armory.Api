using System.Threading;
using System.Threading.Tasks;
using Armory.Armament.Weapons.Application.Find;
using Armory.Armament.Weapons.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Weapons.Application.Update
{
    public class UpdateWeaponCommandHandler : CommandHandler<UpdateWeaponCommand>
    {
        private readonly WeaponFinder _finder;
        private readonly WeaponUpdater _updater;

        public UpdateWeaponCommandHandler(WeaponUpdater updater, WeaponFinder finder)
        {
            _updater = updater;
            _finder = finder;
        }

        protected override async Task Handle(UpdateWeaponCommand request, CancellationToken cancellationToken)
        {
            var weapon = await _finder.Find(request.Code);
            if (weapon == null)
            {
                throw new WeaponNotFound();
            }

            await _updater.Update(weapon, request.Type, request.Mark, request.Model, request.Caliber,
                request.Series, request.Lot, request.NumberOfProviders, request.ProviderCapacity,
                request.QuantityAvailable);
        }
    }
}
