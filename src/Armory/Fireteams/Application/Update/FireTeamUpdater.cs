using System.Threading.Tasks;
using Armory.Fireteams.Domain;
using Armory.Shared.Domain.Persistence.EntityFramework;

namespace Armory.Fireteams.Application.Update;

public class FireTeamUpdater
{
    private readonly IUnitWork _unitWork;

    public FireTeamUpdater(IUnitWork unitWork)
    {
        _unitWork = unitWork;
    }

    public async Task Update(Fireteam fireTeam, string newName)
    {
        fireTeam.Name = newName;
        await _unitWork.SaveChanges();
    }
}
