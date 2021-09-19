using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Fireteams.Application.Create
{
    public class CreateFireteamCommandHandler : CommandHandler<CreateFireteamCommand>
    {
        private readonly FireteamCreator _creator;

        public CreateFireteamCommandHandler(FireteamCreator creator)
        {
            _creator = creator;
        }

        protected override async Task Handle(CreateFireteamCommand request, CancellationToken cancellationToken)
        {
            await _creator.Create(request);
        }
    }
}
