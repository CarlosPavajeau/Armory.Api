using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.AddItem
{
    public class
        AddAssignedWeaponMagazineFormatItemCommandHandler : ICommandHandler<AddAssignedWeaponMagazineFormatItemCommand,
            int>
    {
        private readonly AssignedWeaponMagazineFormatItemAdder _adder;

        public AddAssignedWeaponMagazineFormatItemCommandHandler(AssignedWeaponMagazineFormatItemAdder adder)
        {
            _adder = adder;
        }

        public async Task<int> Handle(AddAssignedWeaponMagazineFormatItemCommand request,
            CancellationToken cancellationToken)
        {
            var item = await _adder.AddItem(
                request.FormatId,
                request.TroopId,
                request.WeaponCode,
                request.CartridgeOfLife,
                request.VerifiedInPhysical,
                request.Novelty,
                request.AmmunitionQuantity,
                request.AmmunitionLot,
                request.Observations);

            return item.Id;
        }
    }
}
