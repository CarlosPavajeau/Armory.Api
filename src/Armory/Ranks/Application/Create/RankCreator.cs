using System.Threading.Tasks;
using Armory.Ranks.Domain;
using AutoMapper;

namespace Armory.Ranks.Application.Create
{
    public class RankCreator
    {
        private readonly IMapper _mapper;
        private readonly IRanksRepository _repository;

        public RankCreator(IRanksRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(CreateRankCommand command)
        {
            var rank = _mapper.Map<Rank>(command);
            await _repository.Save(rank);
        }
    }
}
