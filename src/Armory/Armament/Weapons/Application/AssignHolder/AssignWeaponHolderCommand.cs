using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Weapons.Application.AssignHolder
{
    public class AssignWeaponHolderCommand : Command
    {
        public AssignWeaponHolderCommand(string weaponSerial, string troopId)
        {
            WeaponSerial = weaponSerial;
            TroopId = troopId;
        }

        public string WeaponSerial { get; }
        public string TroopId { get; }
    }
}
