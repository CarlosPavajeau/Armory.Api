using Armory.Fireteams.Domain;

namespace Armory.Test.FireTeams
{
    public class FireTeamsInfrastructureTestCase : ArmoryContextInfrastructureTestCase
    {
        protected IFireteamsRepository Repository => GetService<IFireteamsRepository>();
    }
}
