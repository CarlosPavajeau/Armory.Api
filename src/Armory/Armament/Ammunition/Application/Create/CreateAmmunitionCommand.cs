using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Ammunition.Application.Create
{
    public class CreateAmmunitionCommand : Command
    {
        public string Lot { get; init; }
        public string Type { get; init; }
        public string Mark { get; init; }
        public string Caliber { get; init; }
        public int QuantityAvailable { get; init; }
        public string FlightCode { get; init; }
    }
}
