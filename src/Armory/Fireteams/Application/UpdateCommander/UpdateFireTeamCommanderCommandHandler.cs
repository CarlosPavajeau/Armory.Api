using System.Threading;
using System.Threading.Tasks;
using Armory.Fireteams.Application.Find;
using Armory.Fireteams.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Fireteams.Application.UpdateCommander
{
    public class UpdateFireTeamCommanderCommandHandler : CommandHandler<UpdateFireTeamCommanderCommand>
    {
        private readonly FireteamFinder _finder;
        private readonly FireTeamCommanderUpdater _updater;

        public UpdateFireTeamCommanderCommandHandler(FireteamFinder finder, FireTeamCommanderUpdater updater)
        {
            _finder = finder;
            _updater = updater;
        }


        protected override async Task Handle(UpdateFireTeamCommanderCommand request,
            CancellationToken cancellationToken)
        {
            var fireTeam = await _finder.Find(request.Code, false);
            if (fireTeam is null)
            {
                throw new FireTeamNotFoundException();
            }

            await _updater.UpdateCommander(fireTeam, request.PersonId);
        }
    }
}
