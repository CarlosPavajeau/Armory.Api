using Armory.Shared.Domain.Bus.Command;

namespace Armory.Fireteams.Application.Update;

public class UpdateFireTeamCommand : Command
{
    public string Code { get; set; }
    public string Name { get; init; }
}
