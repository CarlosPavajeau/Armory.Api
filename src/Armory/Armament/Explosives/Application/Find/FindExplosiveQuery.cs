using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Explosives.Application.Find
{
    public class FindExplosiveQuery : Query<ExplosiveResponse>
    {
        public FindExplosiveQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
