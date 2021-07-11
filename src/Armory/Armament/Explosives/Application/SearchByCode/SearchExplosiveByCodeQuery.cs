using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Explosives.Application.SearchByCode
{
    public class SearchExplosiveByCodeQuery : Query
    {
        public string Code { get; }

        public SearchExplosiveByCodeQuery(string code)
        {
            Code = code;
        }
    }
}
