using Armory.Degrees.Domain;

namespace Armory.Degrees.Application
{
    public class DegreeResponse
    {
        public DegreeResponse(int id, string name, int rankId)
        {
            Id = id;
            Name = name;
            RankId = rankId;
        }

        public int Id { get; }
        public string Name { get; }
        public int RankId { get; }

        public static DegreeResponse FromAggregate(Degree degree)
        {
            return new DegreeResponse(degree.Id, degree.Name, degree.RankId);
        }
    }
}
