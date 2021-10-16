using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Equipments.Application.Update
{
    public class UpdateEquipmentCommand : Command
    {
        public UpdateEquipmentCommand(string serial, string type, string model, string series, int quantityAvailable)
        {
            Serial = serial;
            Type = type;
            Model = model;
            Series = series;
            QuantityAvailable = quantityAvailable;
        }

        public string Serial { get; }
        public string Type { get; }
        public string Model { get; }
        public string Series { get; }
        public int QuantityAvailable { get; }
    }
}
