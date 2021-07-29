using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Explosives.Application.SearchAll
{
    public class SearchAllExplosivesQuery : Query<IEnumerable<ExplosiveResponse>>
    {
    }
}
