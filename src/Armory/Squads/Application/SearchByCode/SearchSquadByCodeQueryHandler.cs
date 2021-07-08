using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.SearchByCode
{
    public class SearchSquadByCodeQueryHandler : IQueryHandler<SearchSquadByCodeQuery, SquadResponse>
    {
        private readonly SquadByCodeSearcher _searcher;

        public SearchSquadByCodeQueryHandler(SquadByCodeSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<SquadResponse> Handle(SearchSquadByCodeQuery query)
        {
            return await _searcher.Search(query.Code);
        }
    }
}
