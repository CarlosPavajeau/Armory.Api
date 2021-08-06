using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squadrons.Application.Find
{
    public class FindSquadronQuery : Query<SquadronResponse>
    {
        public FindSquadronQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
