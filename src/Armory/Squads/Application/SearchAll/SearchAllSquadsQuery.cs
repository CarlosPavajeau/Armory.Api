using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.SearchAll
{
    public class SearchAllSquadsQuery : Query<IEnumerable<SquadResponse>>
    {
    }
}
