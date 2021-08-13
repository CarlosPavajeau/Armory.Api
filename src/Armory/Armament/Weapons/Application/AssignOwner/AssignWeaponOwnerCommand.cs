using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Weapons.Application.AssignOwner
{
    public class AssignWeaponOwnerCommand : Command
    {
        public AssignWeaponOwnerCommand(string weaponCode, string troopId)
        {
            WeaponCode = weaponCode;
            TroopId = troopId;
        }

        public string WeaponCode { get; }
        public string TroopId { get; }
    }
}
