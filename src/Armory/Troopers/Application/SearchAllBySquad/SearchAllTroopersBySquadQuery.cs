using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Troopers.Application.SearchAllBySquad
{
    public class SearchAllTroopersBySquadQuery : Query<IEnumerable<TroopResponse>>
    {
        public SearchAllTroopersBySquadQuery(string squadCode)
        {
            SquadCode = squadCode;
        }

        public string SquadCode { get; }
    }
}
