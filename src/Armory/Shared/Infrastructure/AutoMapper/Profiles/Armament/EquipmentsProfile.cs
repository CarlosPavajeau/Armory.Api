using Armory.Armament.Equipments.Application;
using Armory.Armament.Equipments.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Armament
{
    public class EquipmentsProfile : Profile
    {
        public EquipmentsProfile()
        {
            CreateMap<Equipment, EquipmentResponse>();
        }
    }
}
