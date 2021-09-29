using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.CheckExists
{
    public class CheckWeaponExistsQuery : Query<bool>
    {
        public CheckWeaponExistsQuery(string serial)
        {
            Serial = serial;
        }

        public string Serial { get; }
    }
}
