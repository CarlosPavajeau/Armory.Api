using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Ammunition.Application.SearchByCode
{
    public class SearchAmmunitionByCodeQuery : Query
    {
        public string Code { get; }

        public SearchAmmunitionByCodeQuery(string code)
        {
            Code = code;
        }
    }
}
