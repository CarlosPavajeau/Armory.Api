using Armory.Api.Controllers.Armament.Weapons.Requests;
using Armory.Armament.Weapons.Application.Create;
using Armory.Armament.Weapons.Application.Update;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class ArmamentProfile : Profile
    {
        public ArmamentProfile()
        {
            CreateMap<CreateWeaponRequest, CreateWeaponCommand>();
            CreateMap<UpdateWeaponRequest, UpdateWeaponCommand>();
        }
    }
}
