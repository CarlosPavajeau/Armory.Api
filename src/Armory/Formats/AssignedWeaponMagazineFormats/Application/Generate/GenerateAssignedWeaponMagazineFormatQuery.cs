using System.IO;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.Generate
{
    public class GenerateAssignedWeaponMagazineFormatQuery : Query<MemoryStream>
    {
        public GenerateAssignedWeaponMagazineFormatQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
