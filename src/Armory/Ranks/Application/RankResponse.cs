using Armory.Ranks.Domain;

namespace Armory.Ranks.Application
{
    public class RankResponse
    {
        public int Id { get; }
        public string Name { get; }

        public RankResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static RankResponse FromAggregate(Rank rank)
        {
            return new(rank.Id, rank.Name);
        }
    }
}
