using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Equipments.Application.CheckExists
{
    public class CheckEquipmentExistsQueryHandler : IQueryHandler<CheckEquipmentExistsQuery, bool>
    {
        private readonly EquipmentExistsChecker _checker;

        public CheckEquipmentExistsQueryHandler(EquipmentExistsChecker checker)
        {
            _checker = checker;
        }

        public async Task<bool> Handle(CheckEquipmentExistsQuery query)
        {
            return await _checker.Exists(query.Code);
        }
    }
}
