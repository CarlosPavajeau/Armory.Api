using Armory.Shared.Domain.Bus.Command;

namespace Armory.Fireteams.Application.UpdateCommander
{
    public class UpdateFireTeamCommanderCommand : Command
    {
        public string Code { get; init; }
        public string PersonId { get; init; }
    }
}
