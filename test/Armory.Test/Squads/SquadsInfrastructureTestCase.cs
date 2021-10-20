using Armory.Squads.Domain;

namespace Armory.Test.Squads
{
    public class SquadsInfrastructureTestCase : ArmoryContextInfrastructureTestCase
    {
        protected ISquadsRepository Repository => GetService<ISquadsRepository>();
    }
}
