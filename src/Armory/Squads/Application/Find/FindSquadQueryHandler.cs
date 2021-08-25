using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Squads.Application.Find
{
    public class FindSquadQueryHandler : IQueryHandler<FindSquadQuery, SquadResponse>
    {
        private readonly SquadFinder _finder;
        private readonly IMapper _mapper;

        public FindSquadQueryHandler(SquadFinder finder, IMapper mapper)
        {
            _finder = finder;
            _mapper = mapper;
        }

        public async Task<SquadResponse> Handle(FindSquadQuery request, CancellationToken cancellationToken)
        {
            var squad = await _finder.Find(request.Code);
            return squad == null ? null : _mapper.Map<SquadResponse>(squad);
        }
    }
}
