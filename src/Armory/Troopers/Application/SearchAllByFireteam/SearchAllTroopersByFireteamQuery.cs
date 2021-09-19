using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Troopers.Application.SearchAllByFireteam
{
    public class SearchAllTroopersByFireteamQuery : Query<IEnumerable<TroopResponse>>
    {
        public SearchAllTroopersByFireteamQuery(string fireteamCode)
        {
            FireteamCode = fireteamCode;
        }

        public string FireteamCode { get; }
    }
}
