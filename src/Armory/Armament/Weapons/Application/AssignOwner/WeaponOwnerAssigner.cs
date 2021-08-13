using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;
using Armory.Shared.Domain.Persistence.EntityFramework;

namespace Armory.Armament.Weapons.Application.AssignOwner
{
    public class WeaponOwnerAssigner
    {
        private readonly IWeaponsRepository _repository;
        private readonly IUnitWork _unitWork;

        public WeaponOwnerAssigner(IWeaponsRepository repository, IUnitWork unitWork)
        {
            _repository = repository;
            _unitWork = unitWork;
        }

        public async Task AssignOwner(string weaponCode, string troopId)
        {
            var weapon = await _repository.Find(weaponCode, false);
            if (weapon == null)
            {
                throw new WeaponNotFound();
            }

            weapon.TroopId = troopId;
            weapon.State = WeaponState.Assigned;

            await _unitWork.SaveChanges();
        }
    }
}
