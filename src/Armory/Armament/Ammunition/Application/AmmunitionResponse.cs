namespace Armory.Armament.Ammunition.Application
{
    public class AmmunitionResponse
    {
        public string Lot { get; init; }
        public string Type { get; init; }
        public string Mark { get; init; }
        public string Caliber { get; init; }
        public int QuantityAvailable { get; init; }
        public string FlightCode { get; init; }
    }
}
