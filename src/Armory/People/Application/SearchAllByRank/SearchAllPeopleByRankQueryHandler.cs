using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.People.Application.SearchAllByRank
{
    public class
        SearchAllPeopleByRankQueryHandler : IQueryHandler<SearchAllPeopleByRankQuery, IEnumerable<PersonResponse>>
    {
        private readonly IMapper _mapper;
        private readonly PeopleByRankSearcher _searcher;

        public SearchAllPeopleByRankQueryHandler(PeopleByRankSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonResponse>> Handle(SearchAllPeopleByRankQuery request,
            CancellationToken cancellationToken)
        {
            var people = await _searcher.SearchAllByRank(request.RankName);

            return _mapper.Map<IEnumerable<PersonResponse>>(people);
        }
    }
}
