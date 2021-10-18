using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Create
{
    public class CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommandHandler : ICommandHandler<
        CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommand, int>
    {
        private readonly WarMaterialAndSpecialEquipmentAssignmentFormatCreator _creator;

        public CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommandHandler(
            WarMaterialAndSpecialEquipmentAssignmentFormatCreator creator)
        {
            _creator = creator;
        }

        public async Task<int> Handle(CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommand request,
            CancellationToken cancellationToken)
        {
            var format = await _creator.Create(
                request.Code,
                request.Validity,
                request.Place,
                request.Date,
                request.SquadCode,
                request.FlightCode,
                request.Warehouse,
                request.Purpose,
                request.DocMovement,
                request.PhysicalLocation,
                request.Others,
                request.Weapons,
                request.Ammunition.ToDictionary(c => c.AmmunitionLot, c => c.Quantity),
                request.Equipments.ToDictionary(c => c.EquipmentSerial, c => c.Quantity),
                request.Explosives.ToDictionary(c => c.ExplosiveSerial, c => c.Quantity));

            return format.Id;
        }
    }
}
