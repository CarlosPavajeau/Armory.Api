using Armory.Shared.Domain.Bus.Query;

namespace Armory.Degrees.Application.SearchAllByRank
{
    public class SearchAllDegreesByRankQuery : Query
    {
        public int RankId { get; }

        public SearchAllDegreesByRankQuery(int rankId)
        {
            RankId = rankId;
        }
    }
}
