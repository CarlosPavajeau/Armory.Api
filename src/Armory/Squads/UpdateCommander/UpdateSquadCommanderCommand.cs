using Armory.Shared.Domain.Bus.Command;

namespace Armory.Squads.UpdateCommander
{
    public class UpdateSquadCommanderCommand : Command
    {
        public string Code { get; init; }
        public string PersonId { get; init; }
    }
}
