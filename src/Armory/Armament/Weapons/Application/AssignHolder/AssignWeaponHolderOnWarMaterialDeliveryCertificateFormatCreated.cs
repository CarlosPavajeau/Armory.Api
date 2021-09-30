using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Event;
using Armory.Shared.Domain.Formats.WarMaterialDeliveryCertificateFormats;

namespace Armory.Armament.Weapons.Application.AssignHolder
{
    public class
        AssignWeaponHolderOnWarMaterialDeliveryCertificateFormatCreated : IDomainEventSubscriber<
            WarMaterialDeliveryCertificateFormatCreatedDomainEvent>
    {
        private readonly WeaponHolderAssigner _assigner;

        public AssignWeaponHolderOnWarMaterialDeliveryCertificateFormatCreated(WeaponHolderAssigner assigner)
        {
            _assigner = assigner;
        }

        public async Task Handle(WarMaterialDeliveryCertificateFormatCreatedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            var holder = notification.TroopId;
            foreach (var weapon in notification.Weapons)
            {
                await _assigner.AssignHolder(weapon, holder);
            }
        }
    }
}
