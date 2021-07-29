using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Degrees.Application.SearchAllByRank
{
    public class SearchAllDegreesByRankQuery : Query<IEnumerable<DegreeResponse>>
    {
        public int RankId { get; }

        public SearchAllDegreesByRankQuery(int rankId)
        {
            RankId = rankId;
        }
    }
}
