using Armory.Shared.Domain.Bus.Command;

namespace Armory.Squads.Application.Create
{
    public class CreateSquadCommand : Command
    {
        public string Code { get; init; }
        public string Name { get; init; }
        public string PersonId { get; init; }
    }
}
