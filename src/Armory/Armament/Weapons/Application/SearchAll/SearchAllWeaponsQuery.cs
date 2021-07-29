using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.SearchAll
{
    public class SearchAllWeaponsQuery : Query<IEnumerable<WeaponResponse>>
    {
    }
}
