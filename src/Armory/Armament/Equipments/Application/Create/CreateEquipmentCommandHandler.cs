using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Equipments.Application.Create
{
    public class CreateEquipmentCommandHandler : CommandHandler<CreateEquipmentCommand>
    {
        private readonly EquipmentCreator _creator;

        public CreateEquipmentCommandHandler(EquipmentCreator creator)
        {
            _creator = creator;
        }

        protected override async Task Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            await _creator.Create(request.Code, request.Type, request.Model, request.Series, request.QuantityAvailable);
        }
    }
}
