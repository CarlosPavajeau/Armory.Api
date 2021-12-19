using System.Threading;
using System.Threading.Tasks;
using Armory.Fireteams.Application.Find;
using Armory.Fireteams.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Fireteams.Application.Update;

public class UpdateFireTeamCommandHandler : CommandHandler<UpdateFireTeamCommand>
{
    private readonly FireteamFinder _finder;
    private readonly FireTeamUpdater _updater;

    public UpdateFireTeamCommandHandler(FireteamFinder finder, FireTeamUpdater updater)
    {
        _finder = finder;
        _updater = updater;
    }

    protected override async Task Handle(UpdateFireTeamCommand request, CancellationToken cancellationToken)
    {
        var fireTeam = await _finder.Find(request.Code);
        if (fireTeam is null)
            throw new FireTeamNotFoundException();

        await _updater.Update(fireTeam, request.Name);
    }
}
