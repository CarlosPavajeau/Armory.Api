using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Weapons.Application.AssignOwner
{
    public class AssignWeaponOwnerCommandHandler : CommandHandler<AssignWeaponOwnerCommand>
    {
        private readonly WeaponOwnerAssigner _assigner;

        public AssignWeaponOwnerCommandHandler(WeaponOwnerAssigner assigner)
        {
            _assigner = assigner;
        }

        protected override async Task Handle(AssignWeaponOwnerCommand request, CancellationToken cancellationToken)
        {
            await _assigner.AssignOwner(request.WeaponSeries, request.TroopId);
        }
    }
}
