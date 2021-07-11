using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Equipments.Application.Find
{
    public class FindEquipmentQuery : Query
    {
        public string Code { get; }

        public FindEquipmentQuery(string code)
        {
            Code = code;
        }
    }
}
