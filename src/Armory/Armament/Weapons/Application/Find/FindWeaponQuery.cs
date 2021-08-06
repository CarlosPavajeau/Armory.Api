using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.Find
{
    public class FindWeaponQuery : Query<WeaponResponse>
    {
        public FindWeaponQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
