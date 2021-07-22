using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Equipments.Application.CheckExists
{
    public class CheckEquipmentExistsQuery : Query
    {
        public string Code { get; }

        public CheckEquipmentExistsQuery(string code)
        {
            Code = code;
        }
    }
}
