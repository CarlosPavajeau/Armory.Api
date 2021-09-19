using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Squads.Application.Create
{
    public class CreateSquadCommandHandler : CommandHandler<CreateSquadCommand>
    {
        private readonly SquadCreator _creator;

        public CreateSquadCommandHandler(SquadCreator creator)
        {
            _creator = creator;
        }

        protected override async Task Handle(CreateSquadCommand request, CancellationToken cancellationToken)
        {
            await _creator.Create(request);
        }
    }
}
