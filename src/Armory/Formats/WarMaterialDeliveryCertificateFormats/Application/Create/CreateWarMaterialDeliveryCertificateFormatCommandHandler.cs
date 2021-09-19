using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Create
{
    public class
        CreateWarMaterialDeliveryCertificateFormatCommandHandler : ICommandHandler<
            CreateWarMaterialDeliveryCertificateFormatCommand, int>
    {
        private readonly WarMaterialDeliveryCertificateFormatCreator _creator;

        public CreateWarMaterialDeliveryCertificateFormatCommandHandler(
            WarMaterialDeliveryCertificateFormatCreator creator)
        {
            _creator = creator;
        }

        public async Task<int> Handle(CreateWarMaterialDeliveryCertificateFormatCommand request,
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
                request.Weapons,
                request.Ammunition.ToDictionary(c => c.AmmunitionCode, c => c.Quantity),
                request.Equipments.ToDictionary(c => c.EquipmentCode, c => c.Quantity),
                request.Explosives.ToDictionary(c => c.ExplosiveCode, c => c.Quantity));

            return format.Id;
        }
    }
}
