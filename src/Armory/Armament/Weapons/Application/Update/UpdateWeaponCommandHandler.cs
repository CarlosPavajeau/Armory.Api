using System.Threading.Tasks;
using Armory.Armament.Weapons.Application.Find;
using Armory.Armament.Weapons.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Weapons.Application.Update
{
    public class UpdateWeaponCommandHandler : ICommandHandler<UpdateWeaponCommand>
    {
        private readonly WeaponUpdater _updater;
        private readonly WeaponFinder _finder;

        public UpdateWeaponCommandHandler(WeaponUpdater updater, WeaponFinder finder)
        {
            _updater = updater;
            _finder = finder;
        }

        public async Task Handle(UpdateWeaponCommand command)
        {
            var weapon = await _finder.Find(command.Code);
            if (weapon == null)
            {
                throw new WeaponNotFound();
            }

            await _updater.Update(weapon, command.Type, command.Mark, command.Model, command.Caliber,
                command.Series, command.Lot, command.NumberOfProviders, command.ProviderCapacity,
                command.QuantityAvailable);
        }
    }
}
