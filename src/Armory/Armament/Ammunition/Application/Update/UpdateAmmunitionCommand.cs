using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Ammunition.Application.Update
{
    public class UpdateAmmunitionCommand : Command
    {
        public string Lot { get; set; }
        public string Type { get; set; }
        public string Mark { get; set; }
        public string Caliber { get; set; }
        public int QuantityAvailable { get; set; }
    }
}
