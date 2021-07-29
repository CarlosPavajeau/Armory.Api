using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Troopers.Application.SearchAll
{
    public class SearchAllTroopersQuery : Query<IEnumerable<TroopResponse>>
    {
    }
}
