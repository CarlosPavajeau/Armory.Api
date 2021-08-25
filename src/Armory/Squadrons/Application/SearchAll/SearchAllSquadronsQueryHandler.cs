using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Squadrons.Application.SearchAll
{
    public class SearchAllSquadronsQueryHandler : IQueryHandler<SearchAllSquadronsQuery, IEnumerable<SquadronResponse>>
    {
        private readonly IMapper _mapper;
        private readonly SquadronsSearcher _searcher;

        public SearchAllSquadronsQueryHandler(SquadronsSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SquadronResponse>> Handle(SearchAllSquadronsQuery request,
            CancellationToken cancellationToken)
        {
            var squadrons = await _searcher.SearchAll();
            return _mapper.Map<IEnumerable<SquadronResponse>>(squadrons);
        }
    }
}
