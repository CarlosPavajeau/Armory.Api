using System.Threading.Tasks;
using Armory.Squads.Domain;
using AutoMapper;

namespace Armory.Squads.Application.Create
{
    public class SquadCreator
    {
        private readonly IMapper _mapper;
        private readonly ISquadsRepository _repository;

        public SquadCreator(ISquadsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(CreateSquadCommand command)
        {
            var squad = _mapper.Map<Squad>(command);
            await _repository.Save(squad);
        }
    }
}
