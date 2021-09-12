using System.Threading.Tasks;
using Armory.Squadrons.Domain;
using AutoMapper;

namespace Armory.Squadrons.Application.Create
{
    public class SquadronCreator
    {
        private readonly IMapper _mapper;
        private readonly ISquadronsRepository _repository;

        public SquadronCreator(ISquadronsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(CreateSquadronCommand command)
        {
            var squadron = _mapper.Map<Squadron>(command);

            await _repository.Save(squadron);
        }
    }
}
