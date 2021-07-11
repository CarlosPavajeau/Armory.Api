using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.Find
{
    public class FindSquadQuery : Query
    {
        public string Code { get; }

        public FindSquadQuery(string code)
        {
            Code = code;
        }
    }
}
