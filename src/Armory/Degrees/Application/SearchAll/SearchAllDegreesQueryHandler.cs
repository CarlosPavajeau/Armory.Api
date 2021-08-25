using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Degrees.Application.SearchAll
{
    public class SearchAllDegreesQueryHandler : IQueryHandler<SearchAllDegreesQuery, IEnumerable<DegreeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AllDegreesSearcher _searcher;

        public SearchAllDegreesQueryHandler(AllDegreesSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DegreeResponse>> Handle(SearchAllDegreesQuery request,
            CancellationToken cancellationToken)
        {
            var degrees = await _searcher.SearchAll();
            return _mapper.Map<IEnumerable<DegreeResponse>>(degrees);
        }
    }
}
