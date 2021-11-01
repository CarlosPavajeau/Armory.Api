using System.Threading.Tasks;
using Armory.Fireteams.Domain;
using Armory.Shared.Domain.Persistence.EntityFramework;

namespace Armory.Fireteams.Application.UpdateCommander
{
    public class FireTeamCommanderUpdater
    {
        private readonly IUnitWork _unitWork;

        public FireTeamCommanderUpdater(IUnitWork unitWork)
        {
            _unitWork = unitWork;
        }

        public async Task UpdateCommander(Fireteam fireTeam, string personId)
        {
            fireTeam.PersonId = personId;
            await _unitWork.SaveChanges();
        }
    }
}
