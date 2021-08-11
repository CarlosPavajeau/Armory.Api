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
                request.SquadronCode,
                request.SquadCode,
                request.TroopId,
                request.Weapons,
                request.Ammunition,
                request.Equipments,
                request.Explosives);

            return format.Id;
        }
    }
}
