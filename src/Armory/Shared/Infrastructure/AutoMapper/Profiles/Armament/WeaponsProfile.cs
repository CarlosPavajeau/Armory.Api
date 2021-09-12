using Armory.Armament.Weapons.Application;
using Armory.Armament.Weapons.Application.Create;
using Armory.Armament.Weapons.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Armament
{
    public class WeaponsProfile : Profile
    {
        public WeaponsProfile()
        {
            CreateMap<Weapon, WeaponResponse>()
                .ForMember(r => r.OwnerId, ownerId => ownerId.MapFrom(src => src.TroopId))
                .ForMember(r => r.OwnerName,
                    ownerName => ownerName.MapFrom(src =>
                        src.Owner == null
                            ? string.Empty
                            : $"{src.Owner.FirstName} {src.Owner.SecondName} {src.Owner.LastName} {src.Owner.SecondLastName}"));
            CreateMap<CreateWeaponCommand, Weapon>();
        }
    }
}
