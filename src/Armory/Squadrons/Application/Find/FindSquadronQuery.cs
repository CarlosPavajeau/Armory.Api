using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squadrons.Application.Find
{
    public class FindSquadronQuery : Query
    {
        public string Code { get; }

        public FindSquadronQuery(string code)
        {
            Code = code;
        }
    }
}
