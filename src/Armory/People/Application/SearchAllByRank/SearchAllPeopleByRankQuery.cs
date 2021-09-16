using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.SearchAllByRank
{
    public class SearchAllPeopleByRankQuery : Query<IEnumerable<PersonResponse>>
    {
        public string RankName { get; init; }
    }
}
