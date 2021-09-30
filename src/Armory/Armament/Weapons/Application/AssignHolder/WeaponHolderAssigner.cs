using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;
using Armory.Shared.Domain.Persistence.EntityFramework;

namespace Armory.Armament.Weapons.Application.AssignHolder
{
    public class WeaponHolderAssigner
    {
        private readonly IWeaponsRepository _repository;
        private readonly IUnitWork _unitWork;

        public WeaponHolderAssigner(IWeaponsRepository repository, IUnitWork unitWork)
        {
            _repository = repository;
            _unitWork = unitWork;
        }

        public async Task AssignHolder(string weaponSerial, string troopId)
        {
            var weapon = await _repository.Find(weaponSerial, false);
            if (weapon == null) throw new WeaponNotFound();

            weapon.TroopId = troopId;
            weapon.State = WeaponState.Assigned;

            await _unitWork.SaveChanges();
        }
    }
}
