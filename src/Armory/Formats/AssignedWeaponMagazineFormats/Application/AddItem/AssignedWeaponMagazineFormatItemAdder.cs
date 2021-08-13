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

        public async Task AddItem(int formatId, string troopId, string weaponCode, bool cartridgeOfLife,
            bool verifiedInPhysical, bool novelty, int ammunitionQuantity, string ammunitionLot, string observations)
        {
            var format = await _repository.Find(formatId, false);
            if (format == null)
            {
                throw new AssignedWeaponMagazineFormatNotFound();
            }

            format.Records.Add(AssignedWeaponMagazineFormatItem.Create(troopId, weaponCode, cartridgeOfLife,
                verifiedInPhysical, novelty, ammunitionQuantity, ammunitionLot, observations, format));

            await _unitWork.SaveChanges();
        }
    }
}
