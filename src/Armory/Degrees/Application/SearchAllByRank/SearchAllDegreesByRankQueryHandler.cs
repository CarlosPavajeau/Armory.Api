using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Degrees.Application.SearchAllByRank
{
    public class
        SearchAllDegreesByRankQueryHandler : IQueryHandler<SearchAllDegreesByRankQuery, IEnumerable<DegreeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly DegreesByRankSearcher _searcher;

        public SearchAllDegreesByRankQueryHandler(DegreesByRankSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DegreeResponse>> Handle(SearchAllDegreesByRankQuery request,
            CancellationToken cancellationToken)
        {
            var degrees = await _searcher.SearchByRank(request.RankId);
            return _mapper.Map<IEnumerable<DegreeResponse>>(degrees);
        }
    }
}
