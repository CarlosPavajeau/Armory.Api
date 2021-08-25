using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Squads.Application.SearchAll
{
    public class SearchAllSquadsQueryHandler : IQueryHandler<SearchAllSquadsQuery, IEnumerable<SquadResponse>>
    {
        private readonly IMapper _mapper;
        private readonly SquadsSearcher _searcher;

        public SearchAllSquadsQueryHandler(SquadsSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SquadResponse>> Handle(SearchAllSquadsQuery request,
            CancellationToken cancellationToken)
        {
            var squads = await _searcher.SearchAll();
            return _mapper.Map<IEnumerable<SquadResponse>>(squads);
        }
    }
}
