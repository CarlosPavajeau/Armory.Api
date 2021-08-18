using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.SearchAllBySquadron
{
    public class
        SearchAllSquadsBySquadronQueryHandler : IQueryHandler<SearchAllSquadsBySquadronQuery,
            IEnumerable<SquadResponse>>
    {
        private readonly SquadsBySquadronSearcher _searcher;

        public SearchAllSquadsBySquadronQueryHandler(SquadsBySquadronSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<IEnumerable<SquadResponse>> Handle(SearchAllSquadsBySquadronQuery request,
            CancellationToken cancellationToken)
        {
            return await _searcher.SearchAllBySquadron(request.SquadronCode);
        }
    }
}
