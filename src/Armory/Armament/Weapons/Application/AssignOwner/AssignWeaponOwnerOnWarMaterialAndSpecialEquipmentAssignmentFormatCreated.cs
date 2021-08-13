using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Event;
using Armory.Shared.Domain.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;

namespace Armory.Armament.Weapons.Application.AssignOwner
{
    public class AssignWeaponOwnerOnWarMaterialAndSpecialEquipmentAssignmentFormatCreated : IDomainEventSubscriber<
        WarMaterialAndSpecialEquipmentAssignmentFormatCreatedDomainEvent>
    {
        private readonly WeaponOwnerAssigner _assigner;

        public AssignWeaponOwnerOnWarMaterialAndSpecialEquipmentAssignmentFormatCreated(WeaponOwnerAssigner assigner)
        {
            _assigner = assigner;
        }

        public async Task Handle(WarMaterialAndSpecialEquipmentAssignmentFormatCreatedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            foreach (var weaponCode in notification.WeaponCodes)
            {
                await _assigner.AssignOwner(weaponCode, notification.TroopId);
            }
        }
    }
}
