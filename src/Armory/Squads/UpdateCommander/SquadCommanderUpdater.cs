using System.Threading.Tasks;
using Armory.Shared.Domain.Persistence.EntityFramework;
using Armory.Squads.Domain;

namespace Armory.Squads.UpdateCommander
{
    public class SquadCommanderUpdater
    {
        private readonly IUnitWork _unitWork;

        public SquadCommanderUpdater(IUnitWork unitWork)
        {
            _unitWork = unitWork;
        }

        public async Task UpdateCommander(Squad squad, string personId)
        {
            squad.PersonId = personId;
            await _unitWork.SaveChanges();
        }
    }
}
