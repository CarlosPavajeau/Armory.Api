using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Equipments.Application.Find
{
    public class SearchEquipmentByCodeQuery : Query
    {
        public string Code { get; }

        public SearchEquipmentByCodeQuery(string code)
        {
            Code = code;
        }
    }
}
