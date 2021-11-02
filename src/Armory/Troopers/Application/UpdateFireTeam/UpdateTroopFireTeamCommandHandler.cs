using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;
using Armory.Troopers.Application.Find;
using Armory.Troopers.Domain;

namespace Armory.Troopers.Application.UpdateFireTeam
{
    public class UpdateTroopFireTeamCommandHandler : CommandHandler<UpdateTroopFireTeamCommand>
    {
        private readonly TroopFinder _finder;
        private readonly TroopFireTeamUpdater _updater;

        public UpdateTroopFireTeamCommandHandler(TroopFinder finder, TroopFireTeamUpdater updater)
        {
            _finder = finder;
            _updater = updater;
        }

        protected override async Task Handle(UpdateTroopFireTeamCommand request, CancellationToken cancellationToken)
        {
            var troop = await _finder.Find(request.Id, false);
            if (troop is null)
            {
                throw new TroopNotFoundException();
            }

            await _updater.UpdateFireTeam(troop, request.FireTeamCode);
        }
    }
}
