namespace Armory.Armament.Equipments.Application
{
    public class EquipmentResponse
    {
        public string Serial { get; init; }
        public string Type { get; init; }
        public string Model { get; init; }
        public int QuantityAvailable { get; init; }
        public string FlightCode { get; init; }
    }
}
