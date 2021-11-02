using System.Threading.Tasks;
using Armory.Shared.Domain.Persistence.EntityFramework;
using Armory.Troopers.Domain;

namespace Armory.Troopers.Application.UpdateFireTeam
{
    public class TroopFireTeamUpdater
    {
        private readonly IUnitWork _unitWork;

        public TroopFireTeamUpdater(IUnitWork unitWork)
        {
            _unitWork = unitWork;
        }

        public async Task UpdateFireTeam(Troop troop, string fireTeamCode)
        {
            troop.FireteamCode = fireTeamCode;
            await _unitWork.SaveChanges();
        }
    }
}
