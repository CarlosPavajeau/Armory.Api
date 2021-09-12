using System.Threading.Tasks;
using Armory.Armament.Explosives.Domain;
using AutoMapper;

namespace Armory.Armament.Explosives.Application.Create
{
    public class ExplosiveCreator
    {
        private readonly IMapper _mapper;
        private readonly IExplosivesRepository _repository;

        public ExplosiveCreator(IExplosivesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(CreateExplosiveCommand command)
        {
            var explosive = _mapper.Map<Explosive>(command);
            await _repository.Save(explosive);
        }
    }
}
