using Armory.Shared.Domain.Bus.Query;

namespace Armory.Troopers.Application.CheckExists
{
    public class CheckTroopExistsQuery : Query<bool>
    {
        public string Id { get; }

        public CheckTroopExistsQuery(string id)
        {
            Id = id;
        }
    }
}
