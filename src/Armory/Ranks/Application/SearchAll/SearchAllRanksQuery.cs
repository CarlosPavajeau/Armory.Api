using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Ranks.Application.SearchAll
{
    public class SearchAllRanksQuery : Query<IEnumerable<RankResponse>>
    {
    }
}
