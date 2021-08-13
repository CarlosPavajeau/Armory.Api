using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.AddItem
{
    public class
        AddAssignedWeaponMagazineFormatItemCommandHandler : CommandHandler<AddAssignedWeaponMagazineFormatItemCommand>
    {
        private readonly AssignedWeaponMagazineFormatItemAdder _adder;

        public AddAssignedWeaponMagazineFormatItemCommandHandler(AssignedWeaponMagazineFormatItemAdder adder)
        {
            _adder = adder;
        }

        protected override async Task Handle(AddAssignedWeaponMagazineFormatItemCommand request,
            CancellationToken cancellationToken)
        {
            await _adder.AddItem(
                request.FormatId,
                request.TroopId,
                request.WeaponCode,
                request.CartridgeOfLife,
                request.VerifiedInPhysical,
                request.Novelty,
                request.AmmunitionQuantity,
                request.AmmunitionLot,
                request.Observations);
        }
    }
}
