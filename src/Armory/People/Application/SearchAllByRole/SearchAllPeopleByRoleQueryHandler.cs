using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.SearchAllByRole
{
    public class
        SearchAllPeopleByRoleQueryHandler : IQueryHandler<SearchAllPeopleByRoleQuery, IEnumerable<PersonResponse>>
    {
        private readonly PeopleByRoleSearcher _searcher;

        public SearchAllPeopleByRoleQueryHandler(PeopleByRoleSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<IEnumerable<PersonResponse>> Handle(SearchAllPeopleByRoleQuery query)
        {
            return await _searcher.SearchAllByRole(query.RoleName);
        }
    }
}