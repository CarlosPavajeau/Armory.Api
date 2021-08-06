using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Equipments.Application.Create
{
    public class CreateEquipmentCommand : Command
    {
        public CreateEquipmentCommand(string code, string type, string model, string series, int quantityAvailable)
        {
            Code = code;
            Type = type;
            Model = model;
            Series = series;
            QuantityAvailable = quantityAvailable;
        }

        public string Code { get; }
        public string Type { get; }
        public string Model { get; }
        public string Series { get; }
        public int QuantityAvailable { get; }
    }
}
