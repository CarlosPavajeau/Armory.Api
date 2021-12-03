using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;
using Armory.Shared.Domain.Persistence.EntityFramework;
using AutoMapper;

namespace Armory.Armament.Weapons.Application.Update
{
    public class WeaponUpdater
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public WeaponUpdater(IUnitWork unitWork, IMapper mapper)
        {
            _unitWork = unitWork;
            _mapper = mapper;
        }

        public async Task Update(Weapon weapon, UpdateWeaponCommand command)
        {
            _mapper.Map(command, weapon);
            await _unitWork.SaveChanges();
        }
    }
}
