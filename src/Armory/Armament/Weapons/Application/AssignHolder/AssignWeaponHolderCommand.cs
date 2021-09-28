using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Weapons.Application.AssignHolder
{
    public class AssignWeaponHolderCommand : Command
    {
        public AssignWeaponHolderCommand(string weaponSeries, string troopId)
        {
            WeaponSeries = weaponSeries;
            TroopId = troopId;
        }

        public string WeaponSeries { get; }
        public string TroopId { get; }
    }
}
