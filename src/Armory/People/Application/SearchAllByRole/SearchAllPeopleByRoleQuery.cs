using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.SearchAllByRole
{
    public class SearchAllPeopleByRoleQuery : Query<IEnumerable<PersonResponse>>
    {
        public string RoleName { get; }

        public SearchAllPeopleByRoleQuery(string roleName)
        {
            RoleName = roleName;
        }
    }
}
