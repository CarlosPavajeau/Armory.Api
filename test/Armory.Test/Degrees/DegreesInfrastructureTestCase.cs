using Armory.Degrees.Domain;

namespace Armory.Test.Degrees
{
    public class DegreesInfrastructureTestCase : ArmoryContextInfrastructureTestCase
    {
        protected IDegreesRepository Repository => GetService<IDegreesRepository>();
    }
}
