using System.Threading.Tasks;
using Armory.Troopers.Domain;
using AutoMapper;

namespace Armory.Troopers.Application.Create
{
    public class TroopCreator
    {
        private readonly IMapper _mapper;
        private readonly ITroopersRepository _repository;

        public TroopCreator(ITroopersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(CreateTroopCommand command)
        {
            var troop = _mapper.Map<Troop>(command);
            await _repository.Save(troop);
        }
    }
}
