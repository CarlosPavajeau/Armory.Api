using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.SearchByArmoryUserId
{
    public class SearchPersonByArmoryUserIdQuery : Query
    {
        public string ArmoryUserId { get; }

        public SearchPersonByArmoryUserIdQuery(string armoryUserId)
        {
            ArmoryUserId = armoryUserId;
        }
    }
}
