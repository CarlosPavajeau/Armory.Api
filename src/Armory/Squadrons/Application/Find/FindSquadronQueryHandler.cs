using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Squadrons.Application.Find
{
    public class FindSquadronQueryHandler : IQueryHandler<FindSquadronQuery, SquadronResponse>
    {
        private readonly SquadronFinder _finder;
        private readonly IMapper _mapper;

        public FindSquadronQueryHandler(SquadronFinder finder, IMapper mapper)
        {
            _finder = finder;
            _mapper = mapper;
        }

        public async Task<SquadronResponse> Handle(FindSquadronQuery request, CancellationToken cancellationToken)
        {
            var squadron = await _finder.Find(request.Code);
            return squadron == null ? null : _mapper.Map<SquadronResponse>(squadron);
        }
    }
}
