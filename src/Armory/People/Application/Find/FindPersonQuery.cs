using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.Find
{
    public class FindPersonQuery : Query
    {
        public string Id { get; }

        public FindPersonQuery(string id)
        {
            Id = id;
        }
    }
}
