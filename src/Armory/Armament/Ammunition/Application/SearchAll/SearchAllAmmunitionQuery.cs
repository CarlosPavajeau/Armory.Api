using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Ammunition.Application.SearchAll
{
    public class SearchAllAmmunitionQuery : Query<IEnumerable<AmmunitionResponse>>
    {
    }
}
