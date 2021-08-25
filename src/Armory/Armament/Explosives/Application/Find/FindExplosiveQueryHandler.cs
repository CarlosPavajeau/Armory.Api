using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Armament.Explosives.Application.Find
{
    public class FindExplosiveQueryHandler : IQueryHandler<FindExplosiveQuery, ExplosiveResponse>
    {
        private readonly ExplosiveFinder _finder;
        private readonly IMapper _mapper;

        public FindExplosiveQueryHandler(ExplosiveFinder finder, IMapper mapper)
        {
            _finder = finder;
            _mapper = mapper;
        }

        public async Task<ExplosiveResponse> Handle(FindExplosiveQuery request, CancellationToken cancellationToken)
        {
            var explosive = await _finder.Find(request.Code);
            return explosive == null ? null : _mapper.Map<ExplosiveResponse>(explosive);
        }
    }
}
