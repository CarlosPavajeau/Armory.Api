using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Squads.Application.SearchAllBySquadron
{
    public class
        SearchAllSquadsBySquadronQueryHandler : IQueryHandler<SearchAllSquadsBySquadronQuery,
            IEnumerable<SquadResponse>>
    {
        private readonly IMapper _mapper;
        private readonly SquadsBySquadronSearcher _searcher;

        public SearchAllSquadsBySquadronQueryHandler(SquadsBySquadronSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SquadResponse>> Handle(SearchAllSquadsBySquadronQuery request,
            CancellationToken cancellationToken)
        {
            var squads = await _searcher.SearchAllBySquadron(request.SquadronCode);
            return _mapper.Map<IEnumerable<SquadResponse>>(squads);
        }
    }
}
