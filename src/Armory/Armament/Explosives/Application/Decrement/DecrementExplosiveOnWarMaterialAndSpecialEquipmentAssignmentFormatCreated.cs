using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Event;
using Armory.Shared.Domain.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;

namespace Armory.Armament.Explosives.Application.Decrement
{
    public class DecrementExplosiveOnWarMaterialAndSpecialEquipmentAssignmentFormatCreated : IDomainEventSubscriber<
        WarMaterialAndSpecialEquipmentAssignmentFormatCreatedDomainEvent>
    {
        private readonly ExplosiveDecrementer _decrementer;

        public DecrementExplosiveOnWarMaterialAndSpecialEquipmentAssignmentFormatCreated(
            ExplosiveDecrementer decrementer)
        {
            _decrementer = decrementer;
        }

        public async Task Handle(WarMaterialAndSpecialEquipmentAssignmentFormatCreatedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            foreach (var (explosiveCode, quantity) in notification.Explosives)
            {
                await _decrementer.Decrement(explosiveCode, quantity);
            }
        }
    }
}
