namespace Armory.Armament.Explosives.Application
{
    public class ExplosiveResponse
    {
        public string Code { get; init; }
        public string Type { get; init; }
        public string Caliber { get; init; }
        public string Mark { get; init; }
        public string Lot { get; init; }
        public string Series { get; init; }
        public int QuantityAvailable { get; init; }
    }
}
