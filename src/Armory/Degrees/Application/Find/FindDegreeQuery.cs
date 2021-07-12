using Armory.Shared.Domain.Bus.Query;

namespace Armory.Degrees.Application.Find
{
    public class FindDegreeQuery : Query
    {
        public int Id { get; }

        public FindDegreeQuery(int id)
        {
            Id = id;
        }
    }
}
