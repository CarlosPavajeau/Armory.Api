using System.Threading.Tasks;
using Armory.Armament.Equipments.Domain;
using Armory.Shared.Domain.Persistence.EntityFramework;
using AutoMapper;

namespace Armory.Armament.Equipments.Application.Update
{
    public class EquipmentUpdater
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public EquipmentUpdater(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task Update(Equipment equipment, UpdateEquipmentCommand command)
        {
            _mapper.Map(equipment, command);
            await _unitWork.SaveChanges();
        }
    }
}
