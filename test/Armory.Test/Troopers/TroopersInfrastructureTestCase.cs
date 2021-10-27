using Armory.Troopers.Domain;

namespace Armory.Test.Troopers
{
    public class TroopersInfrastructureTestCase : ArmoryContextInfrastructureTestCase
    {
        protected ITroopersRepository Repository => GetService<ITroopersRepository>();
    }
}
