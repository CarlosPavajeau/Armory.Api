using System.Linq;
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
                request.SquadCode,
                request.FlightCode,
                request.FireteamCode,
                request.TroopId,
                request.Warehouse,
                request.Purpose,
                request.DocMovement,
                request.PhysicalLocation,
                request.Others,
                request.Weapons,
                request.Ammunition.ToDictionary(c => c.AmmunitionCode, c => c.Quantity),
                request.Equipments.ToDictionary(c => c.EquipmentSeries, c => c.Quantity),
                request.Explosives.ToDictionary(c => c.ExplosiveSerial, c => c.Quantity));

            return format.Id;
        }
    }
}
