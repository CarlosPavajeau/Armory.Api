using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.Find
{
    public class FindSquadQuery : Query<SquadResponse>
    {
        public string Code { get; init; }
    }
}
