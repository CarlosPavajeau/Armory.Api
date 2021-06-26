using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.SearchAllByRole
{
    public class SearchAllPeopleByRoleQuery : Query
    {
        public string RoleName { get; }

        public SearchAllPeopleByRoleQuery(string roleName)
        {
            RoleName = roleName;
        }
    }
}
