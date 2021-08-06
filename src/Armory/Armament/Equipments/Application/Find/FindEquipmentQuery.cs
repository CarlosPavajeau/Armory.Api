using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Equipments.Application.Find
{
    public class FindEquipmentQuery : Query<EquipmentResponse>
    {
        public FindEquipmentQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
