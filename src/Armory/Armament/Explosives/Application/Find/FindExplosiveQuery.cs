using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Explosives.Application.Find
{
    public class FindExplosiveQuery : Query
    {
        public string Code { get; }

        public FindExplosiveQuery(string code)
        {
            Code = code;
        }
    }
}
