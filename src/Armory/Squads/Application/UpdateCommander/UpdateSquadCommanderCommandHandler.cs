using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;
using Armory.Squads.Application.Find;
using Armory.Squads.Domain;

namespace Armory.Squads.Application.UpdateCommander
{
    public class UpdateSquadCommanderCommandHandler : CommandHandler<UpdateSquadCommanderCommand>
    {
        private readonly SquadFinder _finder;
        private readonly SquadCommanderUpdater _updater;

        public UpdateSquadCommanderCommandHandler(SquadFinder finder, SquadCommanderUpdater updater)
        {
            _finder = finder;
            _updater = updater;
        }

        protected override async Task Handle(UpdateSquadCommanderCommand request, CancellationToken cancellationToken)
        {
            var squad = await _finder.Find(request.Code, false);
            if (squad is null)
            {
                throw new SquadNotFoundException();
            }

            await _updater.UpdateCommander(squad, request.PersonId);
        }
    }
}
