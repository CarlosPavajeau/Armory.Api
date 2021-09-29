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
                        src.Holder == null
                            ? string.Empty
                            : $"{src.Holder.Degree.Name}, {src.Holder.FirstName} {src.Holder.SecondName} {src.Holder.LastName} {src.Holder.SecondLastName}"));
            CreateMap<CreateWeaponCommand, Weapon>();
        }
    }
}
