using Armory.Armament.Equipments.Domain;

namespace Armory.Armament.Equipments.Application
{
    public class EquipmentResponse
    {
        public EquipmentResponse(string code, string type, string model, string series, int quantityAvailable)
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

        public static EquipmentResponse FromAggregate(Equipment equipment)
        {
            return new EquipmentResponse(equipment.Code, equipment.Type, equipment.Model, equipment.Series,
                equipment.QuantityAvailable);
        }
    }
}
