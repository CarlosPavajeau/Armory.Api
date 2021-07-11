using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.Find
{
    public class FindWeaponQuery : Query
    {
        public string Code { get; }

        public FindWeaponQuery(string code)
        {
            Code = code;
        }
    }
}
