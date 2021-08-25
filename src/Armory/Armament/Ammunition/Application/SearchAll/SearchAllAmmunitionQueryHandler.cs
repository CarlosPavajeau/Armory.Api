using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Armament.Ammunition.Application.SearchAll
{
    public class
        SearchAllAmmunitionQueryHandler : IQueryHandler<SearchAllAmmunitionQuery, IEnumerable<AmmunitionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AmmunitionSearcher _searcher;

        public SearchAllAmmunitionQueryHandler(AmmunitionSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AmmunitionResponse>> Handle(SearchAllAmmunitionQuery request,
            CancellationToken cancellationToken)
        {
            var ammunition = await _searcher.SearchAll();
            return _mapper.Map<IEnumerable<AmmunitionResponse>>(ammunition);
        }
    }
}
