using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Equipments.Application.Update
{
    public class UpdateEquipmentCommandHandler : ICommandHandler<UpdateEquipmentCommand>
    {
        private readonly EquipmentUpdater _updater;

        public UpdateEquipmentCommandHandler(EquipmentUpdater updater)
        {
            _updater = updater;
        }

        public async Task Handle(UpdateEquipmentCommand command)
        {
            await _updater.Update(command.Code, command.Type, command.Model, command.Series, command.QuantityAvailable);
        }
    }
}
