using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Armory.Formats.Shared.Domain;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Armory.Shared.Domain.ClosedXML;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Generate
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatGenerator
    {
        private const string FormatName = "FORMATO ASIGNACIÓN MATERIAL DE GUERRA Y EQUIPO ESPECIAL";
        private const string FormatTitle = "FUERZA AÉREA COLOMBIANA";
        private static readonly XLColor HeaderColor = XLColor.FromHtml("#FFFF99");

        private static readonly List<string> WeaponsAndAmmunitionHeader = new()
        {
            "TIPO ARMA", "MARCA", "MODELO", "CALIBRE", "No. ARMA", "CANT. PROVEEDORES", "CAPACIDAD PROVEEDOR",
            "TIPO DE MUNICIÓN", "CALIBRE", "MARCA", "LOTE", "CANTIDAD DE MUNICIÓN"
        };

        private static readonly List<string> SpecialEquipmentsHeader = new()
        {
            "ÍTEM", "TIPO", "MODELO", "SERIE", "CANTIDAD"
        };

        private static readonly List<string> ExplosivesHeader = new()
        {
            "TIPO DE MUNICIÓN", "CALIBRE", "MARCA", "LOTE", "No. SERIE", "CANTIDAD"
        };

        private readonly IHostingEnvironment _environment;
        private readonly IWorksheetManager _worksheetManager;

        public WarMaterialAndSpecialEquipmentAssignmentFormatGenerator(IHostingEnvironment environment,
            IWorksheetManager worksheetManager)
        {
            _environment = environment;
            _worksheetManager = worksheetManager;
        }

        private void MakeWorksheetHeader(IXLWorksheet worksheet, WarMaterialAndSpecialEquipmentAssignmentFormat format)
        {
            _worksheetManager.SetRowsHeight(worksheet.Rows(1, 3), 33);
            _worksheetManager.SetColumnsWidth(worksheet.Columns("B:M"), 17);
            worksheet.Column("A").Width = 4;
            _worksheetManager.SetCommonRangeStyles(worksheet.Range("A1:M3"));

            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A1:B3"), "ArmoryImage");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("C1:K1"), FormatTitle);
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("C2:K3"), FormatName);

            worksheet.Cell("L1").Value = "Código";
            worksheet.Cell("L2").Value = "Versión";
            worksheet.Cell("L3").Value = "Vigencia";

            worksheet.Cell("M1").Value = format.Code;
            worksheet.Cell("M2").Value = 4;
            worksheet.Cell("M3").Value = format.Validity.ToString("d");
        }

        private void MakeWorksheetMainInfo(IXLWorksheet worksheet,
            WarMaterialAndSpecialEquipmentAssignmentFormat format)
        {
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("K5:M5"), $"FORMATO ACTA No. {format.Id}");

            _worksheetManager.SetRangeFontBold(worksheet.Range("K5:M5"), true);
            _worksheetManager.SetRangeFontBold(worksheet.Range("A6:M17"), true);
            _worksheetManager.SetRangeFontSize(worksheet.Range("A6:M17"), 12);

            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A6:F6"),
                $"Lugar y fecha: {format.Place}, {format.Date:d}");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A7:F7"), $"Unidad: {format.SquadronCode}");

            var warehouse = format.Warehouse == Warehouse.Air ? "AÉREO" : "TERRESTRE";
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("H7:M7"),
                $"ALMACÉN DE ARMAMENTO: {warehouse}");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A8:F8"), $"Solicitante: {format.TroopId}");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A9:F9"), $"Dependencia: {format.SquadCode}");

            var purpose = format.Purpose switch
            {
                Purpose.Instruction => "INSTRUCCIÓN",
                Purpose.Operations => "OPERACIONES",
                Purpose.Verification => "COMPROBACIÓN",
                _ => throw new ArgumentOutOfRangeException(
                    $"Invalid purpose value, the pass value is {format.Purpose}")
            };
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A11:F11"), $"Finalidad: {purpose}");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("I11:M11"), $"OTROS: {format.Others}");

            var docMovement = format.DocMovement == DocMovement.Consumption ? "CONSUMO" : "DEVOLUTIVO";
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A15:F15"), $"DOC MOVIMIENTO: {docMovement}");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A17:D17"),
                $"UBICACIÓN FÍSICA: {format.PhysicalLocation}");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("E17:H17"),
                "(Cuando se encuentre en puntos de custodia)");
        }

        private void MakeWeaponsAndAmmunitionHeader(IXLWorksheet worksheet)
        {
            _worksheetManager.SetCommonRangeStyles(worksheet.Range("A19:M20"));
            _worksheetManager.SetRangeFillBackgroundColor(worksheet.Range("A19:M20"), HeaderColor);

            worksheet.Row(20).Height = 25;
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A19:A20"), "ÍTEM");
            _worksheetManager.SetRangeFontSize(worksheet.Range("A19:A20"), 8);

            _worksheetManager.SetCommonRangeStyles(worksheet.Range("B19:M20"));
            _worksheetManager.SetRangeFontSize(worksheet.Range("B20:M20"), 9);
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("B19:H19"), "ARMAMENTO");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("I19:M19"), "MUNICIÓN");

            _worksheetManager.SetRangeValues(worksheet.Range("B20:M20"), WeaponsAndAmmunitionHeader);
            worksheet.Cell("M20").Style.Alignment.WrapText = true;
            worksheet.Cell("G20").Style.Alignment.WrapText = true;
            worksheet.Cell("H20").Style.Alignment.WrapText = true;
        }

        private int MakeWeaponsAndAmmunitionInfo(IXLWorksheet worksheet,
            WarMaterialAndSpecialEquipmentAssignmentFormat format)
        {
            const int start = 21;
            for (var i = 0; i < format.Weapons.Count; i++)
            {
                var weapon = format.Weapons.ElementAt(i);

                _worksheetManager.SetRangeValues(worksheet.Range($"A{start + i}:H{start + i}"),
                    new List<string>
                    {
                        (i + 1).ToString(),
                        weapon.Type,
                        weapon.Mark,
                        weapon.Model,
                        weapon.Caliber,
                        weapon.Code,
                        weapon.NumberOfProviders.ToString(),
                        weapon.ProviderCapacity.ToString()
                    });
            }

            for (var i = 0; i < format.Ammunition.Count; i++)
            {
                var ammunition = format.Weapons.ElementAt(i);
                var formatAmmunition =
                    format.WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition.First(x =>
                        x.AmmunitionCode == ammunition.Code);

                _worksheetManager.SetRangeValues(worksheet.Range($"I{start + i}:M{start + i}"),
                    new List<string>
                    {
                        ammunition.Type,
                        ammunition.Caliber,
                        ammunition.Mark,
                        ammunition.Lot,
                        formatAmmunition.Quantity.ToString()
                    });
            }

            var maxNumOfElements = Math.Max(format.Ammunition.Count, format.Weapons.Count);
            var workedRange = worksheet.Range($"A21:M{start + maxNumOfElements - 1}");
            _worksheetManager.SetRangeBorders(workedRange, XLBorderStyleValues.Hair);
            _worksheetManager.SetRangeFontName(workedRange, "Arial");
            _worksheetManager.SetRangeAlignment(workedRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);

            return start + maxNumOfElements;
        }

        private void MakeSpecialEquipmentHeader(IXLWorksheet worksheet, int start)
        {
            var headerRange = worksheet.Range($"A{start}:E{start}");
            _worksheetManager.SetCommonRangeStyles(headerRange);
            _worksheetManager.SetRangeFillBackgroundColor(headerRange, HeaderColor);
            _worksheetManager.MergeRangeAndSetValue(headerRange, "EQUIPO ESPECIAL Y ACCESORIOS");

            headerRange = worksheet.Range($"A{start + 1}:E{start + 1}");
            worksheet.Row(start + 1).Height = 25;
            _worksheetManager.SetCommonRangeStyles(headerRange);
            _worksheetManager.SetRangeFontSize(headerRange, 9);
            _worksheetManager.SetRangeFillBackgroundColor(headerRange, HeaderColor);
            _worksheetManager.SetRangeValues(headerRange, SpecialEquipmentsHeader);
        }

        private void MakeExplosivesHeader(IXLWorksheet worksheet, int start)
        {
            var headerRange = worksheet.Range($"H{start}:M{start}");
            _worksheetManager.SetCommonRangeStyles(headerRange);
            _worksheetManager.SetRangeFillBackgroundColor(headerRange, HeaderColor);
            _worksheetManager.MergeRangeAndSetValue(headerRange, "GRANADAS Y EXPLOSIVOS");

            headerRange = worksheet.Range($"H{start + 1}:M{start + 1}");
            worksheet.Row(start + 1).Height = 25;
            _worksheetManager.SetCommonRangeStyles(headerRange);
            _worksheetManager.SetRangeFontSize(headerRange, 9);
            _worksheetManager.SetRangeFillBackgroundColor(headerRange, HeaderColor);
            _worksheetManager.SetRangeValues(headerRange, ExplosivesHeader);
        }

        private int MakeSpecialEquipmentAndExplosivesInfo(IXLWorksheet worksheet,
            WarMaterialAndSpecialEquipmentAssignmentFormat format, int previousEnd)
        {
            var start = previousEnd;
            for (var i = 0; i < format.Equipments.Count; i++)
            {
                var equipment = format.Equipments.ElementAt(i);
                var equipmentFormat =
                    format.WarMaterialAndSpecialEquipmentAssignmentFormatEquipments.First(x =>
                        x.EquipmentCode == equipment.Code);

                _worksheetManager.SetRangeValues(worksheet.Range($"A{start + i}:E{start + i}"),
                    new List<string>
                    {
                        (i + 1).ToString(),
                        equipment.Type,
                        equipment.Model,
                        equipment.Series,
                        equipmentFormat.Quantity.ToString()
                    });
            }

            for (var i = 0; i < format.Explosives.Count; i++)
            {
                var explosive = format.Explosives.ElementAt(i);
                var explosiveFormat =
                    format.WarMaterialAndSpecialEquipmentAssignmentFormatExplosives.First(x =>
                        x.ExplosiveCode == explosive.Code);

                _worksheetManager.SetRangeValues(worksheet.Range($"H{start + i}:M{start + i}"),
                    new List<string>
                    {
                        explosive.Type,
                        explosive.Caliber,
                        explosive.Mark,
                        explosive.Lot,
                        explosive.Series,
                        explosiveFormat.Quantity.ToString()
                    });
            }

            var maxNumOfElements = Math.Max(format.Explosives.Count, format.Equipments.Count);
            var workedRange = worksheet.Range($"A{start}:E{start + maxNumOfElements - 1}");
            _worksheetManager.SetRangeBorders(workedRange, XLBorderStyleValues.Hair);
            _worksheetManager.SetRangeFontName(workedRange, "Arial");
            _worksheetManager.SetRangeAlignment(workedRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);

            workedRange = worksheet.Range($"H{start}:M{start + maxNumOfElements - 1}");
            _worksheetManager.SetRangeBorders(workedRange, XLBorderStyleValues.Hair);
            _worksheetManager.SetRangeFontName(workedRange, "Arial");
            _worksheetManager.SetRangeAlignment(workedRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);

            return start + maxNumOfElements;
        }

        public MemoryStream Generate(WarMaterialAndSpecialEquipmentAssignmentFormat format)
        {
            var workBook = new XLWorkbook();
            var workSheet = workBook.AddWorksheet(format.Code);

            MakeWorksheetHeader(workSheet, format);
            MakeWorksheetMainInfo(workSheet, format);
            MakeWeaponsAndAmmunitionHeader(workSheet);

            var weaponAndAmmunitionEnd = MakeWeaponsAndAmmunitionInfo(workSheet, format);
            MakeSpecialEquipmentHeader(workSheet, weaponAndAmmunitionEnd + 1);
            MakeExplosivesHeader(workSheet, weaponAndAmmunitionEnd + 1);
            MakeSpecialEquipmentAndExplosivesInfo(workSheet, format, weaponAndAmmunitionEnd + 3);

            var memoryStream = new MemoryStream();
            workBook.SaveAs(memoryStream);

            return memoryStream;
        }
    }
}
