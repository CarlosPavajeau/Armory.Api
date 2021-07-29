using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Explosives.Application.Create
{
    public class CreateExplosiveCommandHandler : CommandHandler<CreateExplosiveCommand>
    {
        private readonly ExplosiveCreator _creator;

        public CreateExplosiveCommandHandler(ExplosiveCreator creator)
        {
            _creator = creator;
        }

        protected override async Task Handle(CreateExplosiveCommand request, CancellationToken cancellationToken)
        {
            await _creator.Create(request.Code, request.Type, request.Caliber, request.Mark, request.Lot,
                request.Series, request.QuantityAvailable);
        }
    }
}
