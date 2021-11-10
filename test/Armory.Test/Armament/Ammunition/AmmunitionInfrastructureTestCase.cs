using Armory.Armament.Ammunition.Domain;

namespace Armory.Test.Armament.Ammunition
{
    public class AmmunitionInfrastructureTestCase : ArmoryContextInfrastructureTestCase
    {
        protected IAmmunitionRepository Repository => GetService<IAmmunitionRepository>();
    }
}
