using System;
using System.Threading.Tasks;
using Armory.Formats.AssignedWeaponMagazineFormats.Domain;
using Armory.Formats.Shared.Domain;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.Create
{
    public class AssignedWeaponMagazineFormatCreator
    {
        private readonly IAssignedWeaponMagazineFormatsRepository _repository;

        public AssignedWeaponMagazineFormatCreator(IAssignedWeaponMagazineFormatsRepository repository)
        {
            _repository = repository;
        }

        public async Task<AssignedWeaponMagazineFormat> Create(string code, DateTime validity, string squadronCode,
            string squadCode, Warehouse warehouse, DateTime date, string comments)
        {
            var format =
                AssignedWeaponMagazineFormat.Create(code, validity, squadronCode, squadCode, warehouse, date, comments);

            await _repository.Save(format);

            return format;
        }
    }
}
