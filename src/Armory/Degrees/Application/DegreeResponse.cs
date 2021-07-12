using Armory.Degrees.Domain;

namespace Armory.Degrees.Application
{
    public class DegreeResponse
    {
        public int Id { get; }
        public string Name { get; }

        public DegreeResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static DegreeResponse FromAggregate(Degree degree)
        {
            return new(degree.Id, degree.Name);
        }
    }
}
