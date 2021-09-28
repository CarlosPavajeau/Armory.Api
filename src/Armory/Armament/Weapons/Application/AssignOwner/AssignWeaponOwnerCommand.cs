using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Weapons.Application.AssignOwner
{
    public class AssignWeaponOwnerCommand : Command
    {
        public AssignWeaponOwnerCommand(string weaponSeries, string troopId)
        {
            WeaponSeries = weaponSeries;
            TroopId = troopId;
        }

        public string WeaponSeries { get; }
        public string TroopId { get; }
    }
}
