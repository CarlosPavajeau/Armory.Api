using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Fireteams.Application.Find
{
    public class FindFireteamQueryHandler : IQueryHandler<FindFireteamQuery, FireteamResponse>
    {
        private readonly FireteamFinder _finder;
        private readonly IMapper _mapper;

        public FindFireteamQueryHandler(FireteamFinder finder, IMapper mapper)
        {
            _finder = finder;
            _mapper = mapper;
        }

        public async Task<FireteamResponse> Handle(FindFireteamQuery request, CancellationToken cancellationToken)
        {
            var fireteam = await _finder.Find(request.Code);
            return fireteam == null ? null : _mapper.Map<FireteamResponse>(fireteam);
        }
    }
}
