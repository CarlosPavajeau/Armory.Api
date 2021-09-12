using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;
using AutoMapper;

namespace Armory.Armament.Weapons.Application.Create
{
    public class WeaponCreator
    {
        private readonly IMapper _mapper;
        private readonly IWeaponsRepository _repository;

        public WeaponCreator(IWeaponsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Weapon> Create(CreateWeaponCommand command)
        {
            var weapon = _mapper.Map<Weapon>(command);
            await _repository.Save(weapon);

            return weapon;
        }
    }
}
