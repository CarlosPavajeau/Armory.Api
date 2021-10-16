using System.Threading;
using System.Threading.Tasks;
using Armory.Armament.Equipments.Application.Find;
using Armory.Armament.Equipments.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Equipments.Application.Update
{
    public class UpdateEquipmentCommandHandler : CommandHandler<UpdateEquipmentCommand>
    {
        private readonly EquipmentFinder _finder;
        private readonly EquipmentUpdater _updater;

        public UpdateEquipmentCommandHandler(EquipmentUpdater updater, EquipmentFinder finder)
        {
            _updater = updater;
            _finder = finder;
        }

        protected override async Task Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var equipment = await _finder.Find(request.Serial);
            if (equipment == null)
            {
                throw new EquipmentNotFound();
            }

            await _updater.Update(equipment, request.Type, request.Model, request.Series, request.QuantityAvailable);
        }
    }
}
