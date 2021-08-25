using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Armament.Explosives.Application.SearchAll
{
    public class
        SearchAllExplosivesQueryHandler : IQueryHandler<SearchAllExplosivesQuery, IEnumerable<ExplosiveResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AllExplosivesSearcher _searcher;

        public SearchAllExplosivesQueryHandler(AllExplosivesSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExplosiveResponse>> Handle(SearchAllExplosivesQuery request,
            CancellationToken cancellationToken)
        {
            var explosives = await _searcher.SearchAll();
            return _mapper.Map<IEnumerable<ExplosiveResponse>>(explosives);
        }
    }
}
