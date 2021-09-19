using System.Threading.Tasks;
using Armory.Fireteams.Domain;
using AutoMapper;

namespace Armory.Fireteams.Application.Create
{
    public class FireteamCreator
    {
        private readonly IMapper _mapper;
        private readonly IFireteamsRepository _repository;

        public FireteamCreator(IFireteamsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(CreateFireteamCommand command)
        {
            var fireteam = _mapper.Map<Fireteam>(command);
            await _repository.Save(fireteam);
        }
    }
}
