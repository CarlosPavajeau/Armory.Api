using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Ranks.Application.Find
{
    public class FindRankQueryHandler : IQueryHandler<FindRankQuery, RankResponse>
    {
        private readonly RankFinder _finder;
        private readonly IMapper _mapper;

        public FindRankQueryHandler(RankFinder finder, IMapper mapper)
        {
            _finder = finder;
            _mapper = mapper;
        }

        public async Task<RankResponse> Handle(FindRankQuery request, CancellationToken cancellationToken)
        {
            var rank = await _finder.Find(request.Id);
            return rank == null ? null : _mapper.Map<RankResponse>(rank);
        }
    }
}
