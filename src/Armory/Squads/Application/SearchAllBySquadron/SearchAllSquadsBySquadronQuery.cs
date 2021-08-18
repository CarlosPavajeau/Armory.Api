using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.SearchAllBySquadron
{
    public class SearchAllSquadsBySquadronQuery : Query<IEnumerable<SquadResponse>>
    {
        public SearchAllSquadsBySquadronQuery(string squadronCode)
        {
            SquadronCode = squadronCode;
        }

        public string SquadronCode { get; }
    }
}
