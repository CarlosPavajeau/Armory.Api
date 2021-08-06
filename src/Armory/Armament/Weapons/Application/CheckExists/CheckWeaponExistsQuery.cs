using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.CheckExists
{
    public class CheckWeaponExistsQuery : Query<bool>
    {
        public CheckWeaponExistsQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
