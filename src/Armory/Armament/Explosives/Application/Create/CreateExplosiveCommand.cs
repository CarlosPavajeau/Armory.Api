using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Explosives.Application.Create
{
    public class CreateExplosiveCommand : Command
    {
        public string Serial { get; init; }
        public string Type { get; init; }
        public string Caliber { get; init; }
        public string Mark { get; init; }
        public string Lot { get; init; }
        public int QuantityAvailable { get; init; }
        public string FlightCode { get; set; }
    }
}
