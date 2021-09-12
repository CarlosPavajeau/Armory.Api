using System.Threading.Tasks;
using Armory.Armament.Equipments.Domain;
using AutoMapper;

namespace Armory.Armament.Equipments.Application.Create
{
    public class EquipmentCreator
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentsRepository _repository;

        public EquipmentCreator(IEquipmentsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(CreateEquipmentCommand command)
        {
            var equipment = _mapper.Map<Equipment>(command);
            await _repository.Save(equipment);
        }
    }
}
