using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.SearchAllByRole
{
    public class SearchAllPeopleByRoleQuery : Query<IEnumerable<PersonResponse>>
    {
        public SearchAllPeopleByRoleQuery(string roleName)
        {
            RoleName = roleName;
        }

        public string RoleName { get; }
    }
}
