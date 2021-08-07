using System.Threading;
using System.Threading.Tasks;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Generate;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Create
{
    public class CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommandHandler : ICommandHandler<
        CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommand, int>
    {
        private readonly WarMaterialAndSpecialEquipmentAssignmentFormatCreator _creator;
        private readonly WarMaterialAndSpecialEquipmentAssignmentFormatGenerator _generator;

        public CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommandHandler(
            WarMaterialAndSpecialEquipmentAssignmentFormatCreator creator,
            WarMaterialAndSpecialEquipmentAssignmentFormatGenerator generator)
        {
            _creator = creator;
            _generator = generator;
        }

        public async Task<int> Handle(CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommand request,
            CancellationToken cancellationToken)
        {
            var format = await _creator.Create(
                request.Code,
                request.Validity,
                request.Place,
                request.Date,
                request.SquadronCode,
                request.SquadCode,
                request.TroopId,
                request.Warehouse,
                request.Purpose,
                request.DocMovement,
                request.PhysicalLocation,
                request.Others,
                request.Weapons,
                request.Ammunition,
                request.Equipments,
                request.Explosives);

            return format.Id;
        }
    }
}
