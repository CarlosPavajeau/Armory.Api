using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.Find
{
    public class FindPersonQuery : Query<PersonResponse>
    {
        public FindPersonQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
