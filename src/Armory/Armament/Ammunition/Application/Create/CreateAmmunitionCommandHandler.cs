using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Ammunition.Application.Create
{
    public class CreateAmmunitionCommandHandler : CommandHandler<CreateAmmunitionCommand>
    {
        private readonly AmmunitionCreator _creator;

        public CreateAmmunitionCommandHandler(AmmunitionCreator creator)
        {
            _creator = creator;
        }

        protected override async Task Handle(CreateAmmunitionCommand request, CancellationToken cancellationToken)
        {
            await _creator.Create(request.Code, request.Type, request.Mark, request.Caliber, request.Series,
                request.Lot, request.QuantityAvailable);
        }
    }
}
