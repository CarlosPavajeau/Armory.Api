using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Equipments.Application.CheckExists
{
    public class CheckEquipmentExistsQuery : Query<bool>
    {
        public CheckEquipmentExistsQuery(string serial)
        {
            Serial = serial;
        }

        public string Serial { get; }
    }
}
