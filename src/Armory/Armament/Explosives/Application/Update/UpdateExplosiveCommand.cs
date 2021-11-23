using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Explosives.Application.Update
{
    public class UpdateExplosiveCommand : Command
    {
        public string Serial { get; set; }
        public string Type { get; init; }
        public string Caliber { get; init; }
        public string Mark { get; init; }
        public string Lot { get; init; }
        public int QuantityAvailable { get; init; }
    }
}
