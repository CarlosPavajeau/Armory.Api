using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.CheckExists
{
    public class CheckSquadExistsQuery : Query<bool>
    {
        public string SquadCode { get; init; }
    }
}
