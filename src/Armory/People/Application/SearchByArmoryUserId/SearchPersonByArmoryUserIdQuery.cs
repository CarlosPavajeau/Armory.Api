using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.SearchByArmoryUserId
{
    public class SearchPersonByArmoryUserIdQuery : Query<PersonResponse>
    {
        public string ArmoryUserId { get; }

        public SearchPersonByArmoryUserIdQuery(string armoryUserId)
        {
            ArmoryUserId = armoryUserId;
        }
    }
}
