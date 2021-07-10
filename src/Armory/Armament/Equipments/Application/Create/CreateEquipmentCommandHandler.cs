using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Equipments.Application.Create
{
    public class CreateEquipmentCommandHandler : ICommandHandler<CreateEquipmentCommand>
    {
        private readonly EquipmentCreator _creator;

        public CreateEquipmentCommandHandler(EquipmentCreator creator)
        {
            _creator = creator;
        }

        public async Task Handle(CreateEquipmentCommand command)
        {
            await _creator.Create(command.Code, command.Type, command.Model, command.Series, command.QuantityAvailable);
        }
    }
}
