using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Troopers.Application.SearchAll
{
    public class SearchAllTroopersQueryHandler : IQueryHandler<SearchAllTroopersQuery, IEnumerable<TroopResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AllTroopsSearcher _searcher;

        public SearchAllTroopersQueryHandler(AllTroopsSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TroopResponse>> Handle(SearchAllTroopersQuery request,
            CancellationToken cancellationToken)
        {
            var troopers = await _searcher.SearchAll();
            return _mapper.Map<IEnumerable<TroopResponse>>(troopers);
        }
    }
}
