using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Armament.Ammunition.Application.Find
{
    public class FindAmmunitionQueryHandler : IQueryHandler<FindAmmunitionQuery, AmmunitionResponse>
    {
        private readonly IMapper _mapper;
        private readonly AmmunitionFinder _searcher;

        public FindAmmunitionQueryHandler(AmmunitionFinder searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<AmmunitionResponse> Handle(FindAmmunitionQuery request, CancellationToken cancellationToken)
        {
            var ammunition = await _searcher.Find(request.Code);
            return ammunition == null ? null : _mapper.Map<AmmunitionResponse>(ammunition);
        }
    }
}
