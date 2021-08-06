using Armory.Shared.Domain.Bus.Query;

namespace Armory.Degrees.Application.Find
{
    public class FindDegreeQuery : Query<DegreeResponse>
    {
        public FindDegreeQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
