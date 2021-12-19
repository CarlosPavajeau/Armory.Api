using Armory.Shared.Domain.Bus.Command;

namespace Armory.Squads.Application.Update;

public class UpdateSquadCommand : Command
{
    public string Code { get; set; }
    public string Name { get; init; }
}
