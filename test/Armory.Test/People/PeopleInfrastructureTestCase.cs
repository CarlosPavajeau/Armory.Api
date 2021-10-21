using Armory.People.Domain;

namespace Armory.Test.People
{
    public class PeopleInfrastructureTestCase : ArmoryContextInfrastructureTestCase
    {
        protected IPeopleRepository Repository => GetService<IPeopleRepository>();
    }
}
