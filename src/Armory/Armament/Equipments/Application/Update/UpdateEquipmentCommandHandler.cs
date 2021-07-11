using System.Threading.Tasks;
using Armory.Armament.Equipments.Application.Find;
using Armory.Armament.Equipments.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Equipments.Application.Update
{
    public class UpdateEquipmentCommandHandler : ICommandHandler<UpdateEquipmentCommand>
    {
        private readonly EquipmentUpdater _updater;
        private readonly EquipmentFinder _finder;

        public UpdateEquipmentCommandHandler(EquipmentUpdater updater, EquipmentFinder finder)
        {
            _updater = updater;
            _finder = finder;
        }

        public async Task Handle(UpdateEquipmentCommand command)
        {
            var equipment = await _finder.Find(command.Code);
            if (equipment == null)
            {
                throw new EquipmentNotFound();
            }

            await _updater.Update(equipment, command.Type, command.Model, command.Series, command.QuantityAvailable);
        }
    }
}
