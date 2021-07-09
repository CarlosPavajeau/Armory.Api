using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Ammunition.Application.Create
{
    public class CreateAmmunitionCommandHandler : ICommandHandler<CreateAmmunitionCommand>
    {
        private readonly AmmunitionCreator _creator;

        public CreateAmmunitionCommandHandler(AmmunitionCreator creator)
        {
            _creator = creator;
        }

        public async Task Handle(CreateAmmunitionCommand command)
        {
            await _creator.Create(command.Code, command.Type, command.Mark, command.Caliber, command.Series,
                command.Lot, command.QuantityAvailable);
        }
    }
}
