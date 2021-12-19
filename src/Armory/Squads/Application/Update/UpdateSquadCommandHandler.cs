using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;
using Armory.Squads.Application.Find;
using Armory.Squads.Domain;

namespace Armory.Squads.Application.Update;

public class UpdateSquadCommandHandler : CommandHandler<UpdateSquadCommand>
{
    private readonly SquadFinder _finder;
    private readonly SquadUpdater _updater;

    public UpdateSquadCommandHandler(SquadFinder finder, SquadUpdater updater)
    {
        _finder = finder;
        _updater = updater;
    }

    protected override async Task Handle(UpdateSquadCommand request, CancellationToken cancellationToken)
    {
        var squad = await _finder.Find(request.Code);
        if (squad is null)
            throw new SquadNotFoundException();

        await _updater.Update(squad, request.Name);
    }
}
