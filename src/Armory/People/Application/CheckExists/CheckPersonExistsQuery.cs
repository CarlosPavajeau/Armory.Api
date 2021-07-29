using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.CheckExists
{
    public class CheckPersonExistsQuery : Query<bool>
    {
        public string Id { get; }

        public CheckPersonExistsQuery(string id)
        {
            Id = id;
        }
    }
}
