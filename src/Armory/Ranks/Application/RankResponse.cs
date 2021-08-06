using Armory.Ranks.Domain;

namespace Armory.Ranks.Application
{
    public class RankResponse
    {
        public RankResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }

        public static RankResponse FromAggregate(Rank rank)
        {
            return new RankResponse(rank.Id, rank.Name);
        }
    }
}
