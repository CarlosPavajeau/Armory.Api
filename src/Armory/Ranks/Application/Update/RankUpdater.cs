using System.Threading.Tasks;
using Armory.Ranks.Domain;
using Armory.Shared.Domain.Persistence.EntityFramework;

namespace Armory.Ranks.Application.Update
{
    public class RankUpdater
    {
        private readonly IUnitWork _unitWork;

        public RankUpdater(IUnitWork unitWork)
        {
            _unitWork = unitWork;
        }

        public async Task Update(Rank rank, string newName)
        {
            rank.Name = newName;
            await _unitWork.SaveChanges();
        }
    }
}
