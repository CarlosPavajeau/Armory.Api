using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Ranks.Application.Find
{
    public class FindRankQueryHandler : IQueryHandler<FindRankQuery, RankResponse>
    {
        private readonly RankFinder _finder;

        public FindRankQueryHandler(RankFinder finder)
        {
            _finder = finder;
        }

        public async Task<RankResponse> Handle(FindRankQuery query)
        {
            var rank = await _finder.Find(query.Id);
            return rank == null ? null : RankResponse.FromAggregate(rank);
        }
    }
}
