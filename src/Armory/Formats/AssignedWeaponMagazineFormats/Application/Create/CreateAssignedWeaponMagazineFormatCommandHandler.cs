using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.Create
{
    public class
        CreateAssignedWeaponMagazineFormatCommandHandler : ICommandHandler<CreateAssignedWeaponMagazineFormatCommand,
            int>
    {
        private readonly AssignedWeaponMagazineFormatCreator _creator;

        public CreateAssignedWeaponMagazineFormatCommandHandler(AssignedWeaponMagazineFormatCreator creator)
        {
            _creator = creator;
        }

        public async Task<int> Handle(CreateAssignedWeaponMagazineFormatCommand request,
            CancellationToken cancellationToken)
        {
            var format = await _creator.Create(
                request.Code,
                request.Validity,
                request.SquadronCode,
                request.SquadCode,
                request.Warehouse,
                request.Date,
                request.Comments);

            return format.Id;
        }
    }
}
