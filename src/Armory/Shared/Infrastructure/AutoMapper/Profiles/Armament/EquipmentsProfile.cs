﻿using Armory.Armament.Equipments.Application;
using Armory.Armament.Equipments.Application.Create;
using Armory.Armament.Equipments.Application.Update;
using Armory.Armament.Equipments.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Armament
{
    public class EquipmentsProfile : Profile
    {
        public EquipmentsProfile()
        {
            CreateMap<Equipment, EquipmentResponse>();
            CreateMap<CreateEquipmentCommand, Equipment>();
            CreateMap<UpdateEquipmentCommand, Equipment>()
                .ForMember(e => e.Serial, serial => serial.Ignore());
        }
    }
}
