using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Squadrons.Application.Create
{
    public class CreateSquadronCommandHandler : CommandHandler<CreateSquadronCommand>
    {
        private readonly SquadronCreator _creator;

        public CreateSquadronCommandHandler(SquadronCreator creator)
        {
            _creator = creator;
        }

        protected override async Task Handle(CreateSquadronCommand request, CancellationToken cancellationToken)
        {
            await _creator.Create(request);
        }
    }
}
