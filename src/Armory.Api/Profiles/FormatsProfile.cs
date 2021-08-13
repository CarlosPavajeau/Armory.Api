using Armory.Api.Controllers.Formats.AssignedWeaponMagazineFormats.Requests;
using Armory.Api.Controllers.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Requests;
using Armory.Api.Controllers.Formats.WarMaterialDeliveryCertificateFormats.Requests;
using Armory.Formats.AssignedWeaponMagazineFormats.Application.Create;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Create;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Create;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class FormatsProfile : Profile
    {
        public FormatsProfile()
        {
            CreateMap<CreateWarMaterialAndSpecialEquipmentAssignmentFormatRequest,
                CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommand>();

            CreateMap<CreateWarMaterialDeliveryCertificateFormatRequest,
                CreateWarMaterialDeliveryCertificateFormatCommand>();

            CreateMap<CreateAssignedWeaponMagazineFormatRequest, CreateAssignedWeaponMagazineFormatCommand>();
        }
    }
}
