using Armory.Shared.Domain.Bus.Query;

namespace Armory.Troopers.Application.Find
{
    public class FindTroopQuery : Query<TroopResponse>
    {
        public string Id { get; }

        public FindTroopQuery(string id)
        {
            Id = id;
        }
    }
}
