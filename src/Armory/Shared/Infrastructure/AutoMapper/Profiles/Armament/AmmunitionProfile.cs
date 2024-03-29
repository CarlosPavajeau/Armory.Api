﻿using Armory.Armament.Ammunition.Application;
using Armory.Armament.Ammunition.Application.Create;
using Armory.Armament.Ammunition.Application.Update;
using Armory.Armament.Ammunition.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Armament
{
    public class AmmunitionProfile : Profile
    {
        public AmmunitionProfile()
        {
            CreateMap<Ammunition, AmmunitionResponse>();
            CreateMap<CreateAmmunitionCommand, Ammunition>();
            CreateMap<UpdateAmmunitionCommand, Ammunition>()
                .ForMember(a => a.Lot, lot => lot.Ignore());
        }
    }
}
