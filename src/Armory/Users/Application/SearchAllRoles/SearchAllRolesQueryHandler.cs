using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Users.Application.SearchAllRoles
{
    public class SearchAllRolesQueryHandler : IQueryHandler<SearchAllRolesQuery, IEnumerable<ArmoryRoleResponse>>
    {
        private readonly RoleSearcher _searcher;

        public SearchAllRolesQueryHandler(RoleSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<IEnumerable<ArmoryRoleResponse>> Handle(SearchAllRolesQuery request,
            CancellationToken cancellationToken)
        {
            return await _searcher.SearchAllRoles();
        }
    }
}
