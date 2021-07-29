using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.SearchAll
{
    public class SearchAllPeopleQuery : Query<IEnumerable<PersonResponse>>
    {
    }
}
