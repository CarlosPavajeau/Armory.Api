using System.IO;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.GenerateQR
{
    public class GenerateWeaponQrQuery : Query<MemoryStream>
    {
        public GenerateWeaponQrQuery(string series)
        {
            Series = series;
        }

        public string Series { get; }
    }
}
