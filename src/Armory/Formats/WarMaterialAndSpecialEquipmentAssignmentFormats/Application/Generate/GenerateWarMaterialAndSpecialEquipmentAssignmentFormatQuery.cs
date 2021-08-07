using System.IO;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Generate
{
    public class GenerateWarMaterialAndSpecialEquipmentAssignmentFormatQuery : Query<MemoryStream>
    {
        public GenerateWarMaterialAndSpecialEquipmentAssignmentFormatQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
