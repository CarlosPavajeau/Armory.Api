using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Equipments.Application.Update
{
    public class UpdateEquipmentCommand : Command
    {
        public string Serial { get; set; }
        public string Type { get; init; }
        public string Model { get; init; }
        public int QuantityAvailable { get; init; }
    }
}
