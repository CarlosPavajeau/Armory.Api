using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squadron.Application.SearchByCode
{
    public class SearchSquadronByCodeQueryHandler : IQueryHandler<SearchSquadronByCodeQuery, SquadronResponse>
    {
        private readonly SquadronByCodeSearcher _searcher;


        public SearchSquadronByCodeQueryHandler(SquadronByCodeSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<SquadronResponse> Handle(SearchSquadronByCodeQuery query)
        {
            return await _searcher.Search(query.Code);
        }
    }
}
