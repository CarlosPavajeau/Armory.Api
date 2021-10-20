using Armory.Ranks.Domain;

namespace Armory.Test.Ranks
{
    public class RanksInfrastructureTestCase : ArmoryContextInfrastructureTestCase
    {
        protected IRanksRepository Repository => GetService<IRanksRepository>();
    }
}
