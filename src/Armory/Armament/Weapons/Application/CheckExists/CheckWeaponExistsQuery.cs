using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.CheckExists
{
    public class CheckWeaponExistsQuery : Query
    {
        public string Code { get; }

        public CheckWeaponExistsQuery(string code)
        {
            Code = code;
        }
    }
}
