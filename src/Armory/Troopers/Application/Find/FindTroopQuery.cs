using Armory.Shared.Domain.Bus.Query;

namespace Armory.Troopers.Application.Find
{
    public class FindTroopQuery : Query<TroopResponse>
    {
        public FindTroopQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
