using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.SearchByCode
{
    public class SearchWeaponByCodeQuery : Query
    {
        public string Code { get; }

        public SearchWeaponByCodeQuery(string code)
        {
            Code = code;
        }
    }
}
