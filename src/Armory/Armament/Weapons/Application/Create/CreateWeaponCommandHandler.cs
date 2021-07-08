using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Weapons.Application.Create
{
    public class CreateWeaponCommandHandler : ICommandHandler<CreateWeaponCommand>
    {
        private readonly WeaponCreator _creator;

        public CreateWeaponCommandHandler(WeaponCreator creator)
        {
            _creator = creator;
        }

        public async Task Handle(CreateWeaponCommand command)
        {
            await _creator.Create(command.Code, command.Type, command.Mark, command.Model, command.Caliber,
                command.Series, command.Lot, command.NumberOfProviders, command.ProviderCapacity,
                command.QuantityAvailable);
        }
    }
}
