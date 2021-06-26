using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.SearchAll
{
    public class SearchAllPeopleQueryHandler : IQueryHandler<SearchAllPeopleQuery, IEnumerable<PersonResponse>>
    {
        private readonly PeopleSearcher _searcher;

        public SearchAllPeopleQueryHandler(PeopleSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<IEnumerable<PersonResponse>> Handle(SearchAllPeopleQuery query)
        {
            return await _searcher.SearchAll();
        }
    }
}
