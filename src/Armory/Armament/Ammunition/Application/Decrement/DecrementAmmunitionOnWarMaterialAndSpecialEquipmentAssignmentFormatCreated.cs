using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Event;
using Armory.Shared.Domain.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;

namespace Armory.Armament.Ammunition.Application.Decrement
{
    public class DecrementAmmunitionOnWarMaterialAndSpecialEquipmentAssignmentFormatCreated : IDomainEventSubscriber<
        WarMaterialAndSpecialEquipmentAssignmentFormatCreatedDomainEvent>
    {
        private readonly AmmunitionDecrementer _decrementer;

        public DecrementAmmunitionOnWarMaterialAndSpecialEquipmentAssignmentFormatCreated(
            AmmunitionDecrementer decrementer)
        {
            _decrementer = decrementer;
        }

        public async Task Handle(WarMaterialAndSpecialEquipmentAssignmentFormatCreatedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            foreach (var (ammunitionCode, quantity) in notification.Ammunition)
            {
                await _decrementer.Decrement(ammunitionCode, quantity);
            }
        }
    }
}
