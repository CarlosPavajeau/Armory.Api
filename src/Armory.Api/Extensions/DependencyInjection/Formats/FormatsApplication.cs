using Armory.Formats.AssignedWeaponMagazineFormats.Application.AddItem;
using Armory.Formats.AssignedWeaponMagazineFormats.Application.Create;
using Armory.Formats.AssignedWeaponMagazineFormats.Application.Find;
using Armory.Formats.AssignedWeaponMagazineFormats.Application.Generate;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Create;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Find;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Generate;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Create;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Find;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Generate;
using Microsoft.Extensions.DependencyInjection;

namespace Armory.Api.Extensions.DependencyInjection.Formats
{
    public static class FormatsApplication
    {
        public static IServiceCollection AddFormatsApplication(this IServiceCollection services)
        {
            services
                .AddScoped<WarMaterialAndSpecialEquipmentAssignmentFormatCreator,
                    WarMaterialAndSpecialEquipmentAssignmentFormatCreator>();
            services
                .AddScoped<WarMaterialAndSpecialEquipmentAssignmentFormatFinder,
                    WarMaterialAndSpecialEquipmentAssignmentFormatFinder>();
            services
                .AddScoped<WarMaterialAndSpecialEquipmentAssignmentFormatGenerator,
                    WarMaterialAndSpecialEquipmentAssignmentFormatGenerator>();

            services
                .AddScoped<WarMaterialDeliveryCertificateFormatCreator, WarMaterialDeliveryCertificateFormatCreator>();
            services
                .AddScoped<WarMaterialDeliveryCertificateFormatFinder, WarMaterialDeliveryCertificateFormatFinder>();
            services
                .AddScoped<WarMaterialDeliveryCertificateFormatGenerator,
                    WarMaterialDeliveryCertificateFormatGenerator>();

            services.AddScoped<AssignedWeaponMagazineFormatCreator, AssignedWeaponMagazineFormatCreator>();
            services.AddScoped<AssignedWeaponMagazineFormatFinder, AssignedWeaponMagazineFormatFinder>();
            services.AddScoped<AssignedWeaponMagazineFormatGenerator, AssignedWeaponMagazineFormatGenerator>();
            services.AddScoped<AssignedWeaponMagazineFormatItemAdder, AssignedWeaponMagazineFormatItemAdder>();

            return services;
        }
    }
}
