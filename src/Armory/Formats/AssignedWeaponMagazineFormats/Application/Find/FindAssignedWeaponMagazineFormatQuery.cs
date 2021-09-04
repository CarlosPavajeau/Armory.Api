using Armory.Shared.Domain.Bus.Query;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.Find
{
    public class FindAssignedWeaponMagazineFormatQuery : Query<AssignedWeaponMagazineFormatResponse>
    {
        public FindAssignedWeaponMagazineFormatQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
