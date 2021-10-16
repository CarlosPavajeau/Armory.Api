using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Equipments.Application.Find
{
    public class FindEquipmentQuery : Query<EquipmentResponse>
    {
        public FindEquipmentQuery(string serial)
        {
            Serial = serial;
        }

        public string Serial { get; }
    }
}
