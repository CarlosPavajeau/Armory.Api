using System.Threading.Tasks;
using Armory.Shared.Domain.Persistence.EntityFramework;
using Armory.Squads.Domain;

namespace Armory.Squads.Application.Update;

public class SquadUpdater
{
    private readonly IUnitWork _unitWork;

    public SquadUpdater(IUnitWork unitWork)
    {
        _unitWork = unitWork;
    }

    public async Task Update(Squad squad, string newName)
    {
        squad.Name = newName;
        await _unitWork.SaveChanges();
    }
}
