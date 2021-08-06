using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Equipments.Application.CheckExists
{
    public class CheckEquipmentExistsQuery : Query<bool>
    {
        public CheckEquipmentExistsQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
