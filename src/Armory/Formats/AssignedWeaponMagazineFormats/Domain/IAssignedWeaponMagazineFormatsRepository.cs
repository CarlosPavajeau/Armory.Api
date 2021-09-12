using System.Threading.Tasks;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Domain
{
    public interface IAssignedWeaponMagazineFormatsRepository
    {
        Task Save(AssignedWeaponMagazineFormat format);
        Task<AssignedWeaponMagazineFormat> Find(int id, bool noTracking);
        Task<AssignedWeaponMagazineFormat> Find(int id);
    }
}
