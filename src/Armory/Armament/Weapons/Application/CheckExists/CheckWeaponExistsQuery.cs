using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.CheckExists
{
    public class CheckWeaponExistsQuery : Query<bool>
    {
        public CheckWeaponExistsQuery(string series)
        {
            Series = series;
        }

        public string Series { get; }
    }
}
