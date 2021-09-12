using System.Threading.Tasks;
using Armory.Armament.Ammunition.Domain;
using AutoMapper;

namespace Armory.Armament.Ammunition.Application.Create
{
    public class AmmunitionCreator
    {
        private readonly IMapper _mapper;
        private readonly IAmmunitionRepository _repository;

        public AmmunitionCreator(IAmmunitionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(CreateAmmunitionCommand command)
        {
            var ammunition = _mapper.Map<Domain.Ammunition>(command);

            await _repository.Save(ammunition);
        }
    }
}
