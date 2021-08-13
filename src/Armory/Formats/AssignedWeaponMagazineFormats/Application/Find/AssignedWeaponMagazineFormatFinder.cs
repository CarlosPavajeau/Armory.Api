using System.Threading.Tasks;
using Armory.Formats.AssignedWeaponMagazineFormats.Domain;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.Find
{
    public class AssignedWeaponMagazineFormatFinder
    {
        private readonly IAssignedWeaponMagazineFormatsRepository _repository;

        public AssignedWeaponMagazineFormatFinder(IAssignedWeaponMagazineFormatsRepository repository)
        {
            _repository = repository;
        }

        public async Task<AssignedWeaponMagazineFormat> Find(int id)
        {
            return await _repository.Find(id);
        }
    }
}
