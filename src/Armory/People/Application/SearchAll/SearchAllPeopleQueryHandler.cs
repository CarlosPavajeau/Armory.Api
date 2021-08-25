using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.People.Application.SearchAll
{
    public class SearchAllPeopleQueryHandler : IQueryHandler<SearchAllPeopleQuery, IEnumerable<PersonResponse>>
    {
        private readonly IMapper _mapper;
        private readonly PeopleSearcher _searcher;

        public SearchAllPeopleQueryHandler(PeopleSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonResponse>> Handle(SearchAllPeopleQuery request,
            CancellationToken cancellationToken)
        {
            var people = await _searcher.SearchAll();
            return _mapper.Map<IEnumerable<PersonResponse>>(people);
        }
    }
}
