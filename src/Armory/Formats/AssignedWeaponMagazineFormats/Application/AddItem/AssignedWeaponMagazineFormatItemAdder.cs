using System.Linq;
using System.Threading.Tasks;
using Armory.Formats.AssignedWeaponMagazineFormats.Domain;
using Armory.Shared.Domain.Persistence.EntityFramework;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.AddItem
{
    public class AssignedWeaponMagazineFormatItemAdder
    {
        private readonly IAssignedWeaponMagazineFormatsRepository _repository;
        private readonly IUnitWork _unitWork;

        public AssignedWeaponMagazineFormatItemAdder(IAssignedWeaponMagazineFormatsRepository repository,
            IUnitWork unitWork)
        {
            _repository = repository;
            _unitWork = unitWork;
        }

        public async Task<AssignedWeaponMagazineFormatItem> AddItem(int formatId, string troopId, string weaponSerial,
            bool safetyCartridge,
            bool verifiedInPhysical, bool novelty, int ammunitionQuantity, string ammunitionLot, string observations)
        {
            var format = await _repository.Find(formatId, false);
            if (format == null)
            {
                throw new AssignedWeaponMagazineFormatNotFoundException();
            }

            format.Records.Add(AssignedWeaponMagazineFormatItem.Create(troopId, weaponSerial, safetyCartridge,
                verifiedInPhysical, novelty, ammunitionQuantity, ammunitionLot, observations, format));

            await _unitWork.SaveChanges();

            return format.Records.Last();
        }
    }
}
