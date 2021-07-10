using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Equipments.Application.Update
{
    public class UpdateEquipmentCommand : Command
    {
        public string Code { get; }
        public string Type { get; }
        public string Model { get; }
        public string Series { get; }
        public int QuantityAvailable { get; }

        public UpdateEquipmentCommand(string code, string type, string model, string series, int quantityAvailable)
        {
            Code = code;
            Type = type;
            Model = model;
            Series = series;
            QuantityAvailable = quantityAvailable;
        }
    }
}
