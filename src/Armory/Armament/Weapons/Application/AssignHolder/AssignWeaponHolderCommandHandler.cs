using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Weapons.Application.AssignHolder
{
    public class AssignWeaponHolderCommandHandler : CommandHandler<AssignWeaponHolderCommand>
    {
        private readonly WeaponHolderAssigner _assigner;

        public AssignWeaponHolderCommandHandler(WeaponHolderAssigner assigner)
        {
            _assigner = assigner;
        }

        protected override async Task Handle(AssignWeaponHolderCommand request, CancellationToken cancellationToken)
        {
            await _assigner.AssignOwner(request.WeaponSerial, request.TroopId);
        }
    }
}
