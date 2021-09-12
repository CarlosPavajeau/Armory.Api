using System.Threading.Tasks;
using Armory.Formats.AssignedWeaponMagazineFormats.Domain;
using AutoMapper;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.Create
{
    public class AssignedWeaponMagazineFormatCreator
    {
        private readonly IMapper _mapper;
        private readonly IAssignedWeaponMagazineFormatsRepository _repository;

        public AssignedWeaponMagazineFormatCreator(IAssignedWeaponMagazineFormatsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AssignedWeaponMagazineFormat> Create(CreateAssignedWeaponMagazineFormatCommand command)
        {
            var format = _mapper.Map<AssignedWeaponMagazineFormat>(command);
            await _repository.Save(format);

            return format;
        }
    }
}
