using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Weapons.Application.Update
{
    public class UpdateWeaponCommandHandler : ICommandHandler<UpdateWeaponCommand>
    {
        private readonly WeaponUpdater _updater;

        public UpdateWeaponCommandHandler(WeaponUpdater updater)
        {
            _updater = updater;
        }

        public async Task Handle(UpdateWeaponCommand command)
        {
            await _updater.Update(command.Code, command.Type, command.Mark, command.Model, command.Caliber,
                command.Series, command.Lot, command.NumberOfProviders, command.ProviderCapacity,
                command.QuantityAvailable);
        }
    }
}
