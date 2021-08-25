using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Troopers.Application.Find
{
    public class FindTroopQueryHandler : IQueryHandler<FindTroopQuery, TroopResponse>
    {
        private readonly TroopFinder _finder;
        private readonly IMapper _mapper;

        public FindTroopQueryHandler(TroopFinder finder, IMapper mapper)
        {
            _finder = finder;
            _mapper = mapper;
        }

        public async Task<TroopResponse> Handle(FindTroopQuery request, CancellationToken cancellationToken)
        {
            var troop = await _finder.Find(request.Id);
            return troop == null ? null : _mapper.Map<TroopResponse>(troop);
        }
    }
}
