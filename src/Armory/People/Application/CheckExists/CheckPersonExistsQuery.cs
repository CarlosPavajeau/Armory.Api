using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.CheckExists
{
    public class CheckPersonExistsQuery : Query<bool>
    {
        public CheckPersonExistsQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
