using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squadrons.Application.SearchAll
{
    public class SearchAllSquadronsQuery : Query<IEnumerable<SquadronResponse>>
    {
    }
}
