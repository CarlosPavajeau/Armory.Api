using Armory.Api.Controllers.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Requests;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Create;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class FormatsProfile : Profile
    {
        public FormatsProfile()
        {
            CreateMap<CreateWarMaterialAndSpecialEquipmentAssignmentFormatRequest,
                CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommand>();
        }
    }
}
