using Armory.Formats.AssignedWeaponMagazineFormats.Application;
using Armory.Formats.AssignedWeaponMagazineFormats.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Formats
{
    public class AssignedWeaponMagazineFormatsProfile : Profile
    {
        public AssignedWeaponMagazineFormatsProfile()
        {
            CreateMap<AssignedWeaponMagazineFormat, AssignedWeaponMagazineFormatResponse>();
            CreateMap<AssignedWeaponMagazineFormatItem, AssignedWeaponMagazineFormatItemResponse>();
        }
    }
}
