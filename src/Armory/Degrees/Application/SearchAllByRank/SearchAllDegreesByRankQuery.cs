using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Degrees.Application.SearchAllByRank
{
    public class SearchAllDegreesByRankQuery : Query<IEnumerable<DegreeResponse>>
    {
        public SearchAllDegreesByRankQuery(int rankId)
        {
            RankId = rankId;
        }

        public int RankId { get; }
    }
}
