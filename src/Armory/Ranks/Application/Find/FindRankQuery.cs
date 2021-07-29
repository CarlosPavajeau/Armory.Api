using Armory.Shared.Domain.Bus.Query;

namespace Armory.Ranks.Application.Find
{
    public class FindRankQuery : Query<RankResponse>
    {
        public int Id { get; }

        public FindRankQuery(int id)
        {
            Id = id;
        }
    }
}
