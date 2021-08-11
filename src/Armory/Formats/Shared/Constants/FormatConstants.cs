using System.Collections.Generic;
using ClosedXML.Excel;

namespace Armory.Formats.Shared.Constants
{
    public static class FormatConstants
    {
        public static readonly List<string> WeaponsAndAmmunitionHeader = new()
        {
            "TIPO ARMA", "MARCA", "MODELO", "CALIBRE", "No. ARMA", "CANT. PROVEEDORES", "CAPACIDAD PROVEEDOR",
            "TIPO DE MUNICIÓN", "CALIBRE", "MARCA", "LOTE", "CANTIDAD DE MUNICIÓN"
        };

        public static readonly List<string> SpecialEquipmentsHeader = new()
        {
            "ÍTEM", "TIPO", "MODELO", "SERIE", "CANTIDAD"
        };

        public static readonly List<string> ExplosivesHeader = new()
        {
            "TIPO DE MUNICIÓN", "CALIBRE", "MARCA", "LOTE", "No. SERIE", "CANTIDAD"
        };

        public static string FormatTitle => "FUERZA AÉREA COLOMBIANA";

        public static string WarMaterialDeliveryCertificateFormatName =>
            "FORMATO ACTA DE ENTREGA DE MATERIAL DE GUERRA A CADETES, ALUMNOS Y SOLDADOS";

        public static string WarMaterialAndSpecialEquipmentAssignmentFormatName =>
            "FORMATO ASIGNACIÓN MATERIAL DE GUERRA Y EQUIPO ESPECIAL";

        public static XLColor HeaderColor => XLColor.FromHtml("#FFFF99");
    }
}
