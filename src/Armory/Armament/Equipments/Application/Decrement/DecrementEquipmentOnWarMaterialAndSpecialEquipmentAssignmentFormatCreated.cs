using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Event;
using Armory.Shared.Domain.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;

namespace Armory.Armament.Equipments.Application.Decrement
{
    public class DecrementEquipmentOnWarMaterialAndSpecialEquipmentAssignmentFormatCreated : IDomainEventSubscriber<
        WarMaterialAndSpecialEquipmentAssignmentFormatCreatedDomainEvent>
    {
        private readonly EquipmentDecrementer _decrementer;

        public DecrementEquipmentOnWarMaterialAndSpecialEquipmentAssignmentFormatCreated(
            EquipmentDecrementer decrementer)
        {
            _decrementer = decrementer;
        }

        public async Task Handle(WarMaterialAndSpecialEquipmentAssignmentFormatCreatedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            foreach (var (equipmentCode, quantity) in notification.Equipments)
            {
                await _decrementer.Decrement(equipmentCode, quantity);
            }
        }
    }
}
