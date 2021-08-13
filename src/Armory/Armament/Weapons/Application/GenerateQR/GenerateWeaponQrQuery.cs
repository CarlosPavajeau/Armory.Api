using System.IO;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.GenerateQR
{
    public class GenerateWeaponQrQuery : Query<MemoryStream>
    {
        public GenerateWeaponQrQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
