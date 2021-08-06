using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.Find
{
    public class FindSquadQuery : Query<SquadResponse>
    {
        public FindSquadQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
