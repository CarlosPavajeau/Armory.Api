using System.Threading.Tasks;
using Armory.Degrees.Domain;
using Armory.Shared.Domain.Persistence.EntityFramework;

namespace Armory.Degrees.Application.Update
{
    public class DegreeUpdater
    {
        private readonly IUnitWork _unitWork;

        public DegreeUpdater(IUnitWork unitWork)
        {
            _unitWork = unitWork;
        }

        public async Task Update(Degree degree, string newName)
        {
            degree.Name = newName;
            await _unitWork.SaveChanges();
        }
    }
}
