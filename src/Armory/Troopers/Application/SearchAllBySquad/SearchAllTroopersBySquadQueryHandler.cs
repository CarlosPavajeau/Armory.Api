using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Troopers.Application.SearchAllBySquad
{
    public class
        SearchAllTroopersBySquadQueryHandler : IQueryHandler<SearchAllTroopersBySquadQuery, IEnumerable<TroopResponse>>
    {
        private readonly IMapper _mapper;
        private readonly TroopersBySquadSearcher _searcher;

        public SearchAllTroopersBySquadQueryHandler(TroopersBySquadSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TroopResponse>> Handle(SearchAllTroopersBySquadQuery request,
            CancellationToken cancellationToken)
        {
            var troopers = await _searcher.SearchAllBySquad(request.SquadCode);

            return _mapper.Map<IEnumerable<TroopResponse>>(troopers);
        }
    }
}
