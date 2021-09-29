namespace Armory.Armament.Explosives.Application
{
    public class ExplosiveResponse
    {
        public string Type { get; init; }
        public string Caliber { get; init; }
        public string Mark { get; init; }
        public string Lot { get; init; }
        public string Serial { get; init; }
        public int QuantityAvailable { get; init; }
    }
}
