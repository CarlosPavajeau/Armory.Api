using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Equipments.Application.Create
{
    public class CreateEquipmentCommand : Command
    {
        public string Serial { get; init; }
        public string Type { get; init; }
        public string Model { get; init; }
        public int QuantityAvailable { get; init; }
        public string FlightCode { get; set; }
    }
}
