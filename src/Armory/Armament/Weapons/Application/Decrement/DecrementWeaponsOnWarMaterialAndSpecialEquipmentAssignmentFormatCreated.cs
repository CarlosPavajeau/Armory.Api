using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Event;
using Armory.Shared.Domain.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;

namespace Armory.Armament.Weapons.Application.Decrement
{
    public class DecrementWeaponsOnWarMaterialAndSpecialEquipmentAssignmentFormatCreated : IDomainEventSubscriber<
        WarMaterialAndSpecialEquipmentAssignmentFormatCreatedDomainEvent>
    {
        private readonly WeaponDecrementer _decrementer;

        public DecrementWeaponsOnWarMaterialAndSpecialEquipmentAssignmentFormatCreated(WeaponDecrementer decrementer)
        {
            _decrementer = decrementer;
        }

        public async Task Handle(WarMaterialAndSpecialEquipmentAssignmentFormatCreatedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            foreach (var weaponCode in notification.WeaponCodes)
            {
                await _decrementer.Decrement(weaponCode);
            }
        }
    }
}
