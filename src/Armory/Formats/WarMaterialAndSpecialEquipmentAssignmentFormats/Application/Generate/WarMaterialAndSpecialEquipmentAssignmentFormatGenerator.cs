using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Armory.Formats.Shared.Constants;
using Armory.Formats.Shared.Domain;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Armory.Shared.Domain.ClosedXML;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Generate
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatGenerator
    {
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
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("C1:K1"), FormatConstants.FormatTitle);
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("C2:K3"),
                FormatConstants.WarMaterialAndSpecialEquipmentAssignmentFormatName);

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
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A7:F7"),
                $"Unidad: {format.Unit.Code} - {format.Unit.Name}");

            var warehouse = format.Warehouse == Warehouse.Air ? "AÉREO" : "TERRESTRE";
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("H7:M7"),
                $"ALMACÉN DE ARMAMENTO: {warehouse}");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A8:F8"),
                $"Solicitante: {format.Applicant.Id} - {format.Applicant.FullName}");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A9:F9"),
                $"Dependencia: {format.Dependency.Code} - {format.Dependency.Name}");

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
            _worksheetManager.SetRangeFillBackgroundColor(worksheet.Range("A19:M20"), FormatConstants.HeaderColor);

            worksheet.Row(20).Height = 25;
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A19:A20"), "ÍTEM");
            _worksheetManager.SetRangeFontSize(worksheet.Range("A19:A20"), 8);

            _worksheetManager.SetCommonRangeStyles(worksheet.Range("B19:M20"));
            _worksheetManager.SetRangeFontSize(worksheet.Range("B20:M20"), 9);
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("B19:H19"), "ARMAMENTO");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("I19:M19"), "MUNICIÓN");

            _worksheetManager.SetRangeValues(worksheet.Range("B20:M20"), FormatConstants.WeaponsAndAmmunitionHeader);
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
                        weapon.Series,
                        weapon.NumberOfProviders.ToString(),
                        weapon.ProviderCapacity.ToString()
                    });
            }

            for (var i = 0; i < format.Ammunition.Count; i++)
            {
                var ammunition = format.Ammunition.ElementAt(i);
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
            if (maxNumOfElements == 0) maxNumOfElements = 1;
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
            _worksheetManager.SetRangeFillBackgroundColor(headerRange, FormatConstants.HeaderColor);
            _worksheetManager.MergeRangeAndSetValue(headerRange, "EQUIPO ESPECIAL Y ACCESORIOS");

            headerRange = worksheet.Range($"A{start + 1}:E{start + 1}");
            worksheet.Row(start + 1).Height = 25;
            _worksheetManager.SetCommonRangeStyles(headerRange);
            _worksheetManager.SetRangeFontSize(headerRange, 9);
            _worksheetManager.SetRangeFillBackgroundColor(headerRange, FormatConstants.HeaderColor);
            _worksheetManager.SetRangeValues(headerRange, FormatConstants.SpecialEquipmentsHeader);
        }

        private void MakeExplosivesHeader(IXLWorksheet worksheet, int start)
        {
            var headerRange = worksheet.Range($"H{start}:M{start}");
            _worksheetManager.SetCommonRangeStyles(headerRange);
            _worksheetManager.SetRangeFillBackgroundColor(headerRange, FormatConstants.HeaderColor);
            _worksheetManager.MergeRangeAndSetValue(headerRange, "GRANADAS Y EXPLOSIVOS");

            headerRange = worksheet.Range($"H{start + 1}:M{start + 1}");
            worksheet.Row(start + 1).Height = 25;
            _worksheetManager.SetCommonRangeStyles(headerRange);
            _worksheetManager.SetRangeFontSize(headerRange, 9);
            _worksheetManager.SetRangeFillBackgroundColor(headerRange, FormatConstants.HeaderColor);
            _worksheetManager.SetRangeValues(headerRange, FormatConstants.ExplosivesHeader);
        }

        private int MakeSpecialEquipmentAndExplosivesInfo(IXLWorksheet worksheet,
            WarMaterialAndSpecialEquipmentAssignmentFormat format, int previousEnd)
        {
            for (var i = 0; i < format.Equipments.Count; i++)
            {
                var equipment = format.Equipments.ElementAt(i);
                var equipmentFormat =
                    format.WarMaterialAndSpecialEquipmentAssignmentFormatEquipments.First(x =>
                        x.EquipmentCode == equipment.Code);

                _worksheetManager.SetRangeValues(worksheet.Range($"A{previousEnd + i}:E{previousEnd + i}"),
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

                _worksheetManager.SetRangeValues(worksheet.Range($"H{previousEnd + i}:M{previousEnd + i}"),
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
            if (maxNumOfElements == 0) maxNumOfElements = 1;
            var workedRange = worksheet.Range($"A{previousEnd}:E{previousEnd + maxNumOfElements - 1}");
            _worksheetManager.SetRangeBorders(workedRange, XLBorderStyleValues.Hair);
            _worksheetManager.SetRangeFontName(workedRange, "Arial");
            _worksheetManager.SetRangeAlignment(workedRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);

            workedRange = worksheet.Range($"H{previousEnd}:M{previousEnd + maxNumOfElements - 1}");
            _worksheetManager.SetRangeBorders(workedRange, XLBorderStyleValues.Hair);
            _worksheetManager.SetRangeFontName(workedRange, "Arial");
            _worksheetManager.SetRangeAlignment(workedRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);

            return previousEnd + maxNumOfElements;
        }

        private int MakeWorksheetFooterInfo(IXLWorksheet worksheet, int previousEnd)
        {
            var currentRow = previousEnd + 3;

            var workRange = worksheet.Range($"A{currentRow}:C{currentRow}");
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Hair;
            _worksheetManager.MergeRangeAndSetValue(workRange,
                "Grado - Nombres y Apellidos");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            _worksheetManager.SetRangeFontSize(workRange, 8);
            _worksheetManager.SetRangeFontName(workRange, "Arial");

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Hair;
            _worksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombres y Apellidos");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            _worksheetManager.SetRangeFontSize(workRange, 8);
            _worksheetManager.SetRangeFontName(workRange, "Arial");

            workRange = worksheet.Range($"K{currentRow}:M{currentRow}");
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Hair;
            _worksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombres y Apellidos");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            _worksheetManager.SetRangeFontSize(workRange, 8);
            _worksheetManager.SetRangeFontName(workRange, "Arial");

            ++currentRow;
            worksheet.Row(currentRow).Height = 27;

            workRange = worksheet.Range($"A{currentRow}:C{currentRow}");
            _worksheetManager.MergeRangeAndSetValue(workRange, "Firma y Postfirma Jefe de Almacén (Unidad)");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            _worksheetManager.SetRangeFontSize(workRange, 8);
            _worksheetManager.SetRangeFontName(workRange, "Arial");

            workRange = worksheet.Range($"K{currentRow}:M{currentRow}");
            workRange.Style.Alignment.WrapText = true;
            _worksheetManager.MergeRangeAndSetValue(workRange,
                "Firma y Postfirma Cdte. Esc. Armamento o Cdte. Grupo/Escuadron de Seguridad (Unidad)");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            _worksheetManager.SetRangeFontSize(workRange, 8);
            _worksheetManager.SetRangeFontName(workRange, "Arial");

            currentRow += 3;
            worksheet.Cell($"C{currentRow}").Value = "AUTORIZA:";
            worksheet.Cell($"C{currentRow}").Style.Font.Bold = true;
            worksheet.Cell($"C{currentRow}").Style.Font.FontName = "Arial";

            worksheet.Cell($"F{currentRow}").Value = "SI   [   ]";
            worksheet.Cell($"H{currentRow}").Value = "NO   [   ]";

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            _worksheetManager.SetRangeFontBold(workRange, true);
            _worksheetManager.SetRangeFontSize(workRange, 12);
            _worksheetManager.SetRangeFontName(workRange, "Arial");

            currentRow += 5;
            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Hair;
            _worksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombres y Apellidos");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            _worksheetManager.SetRangeFontSize(workRange, 8);
            _worksheetManager.SetRangeFontName(workRange, "Arial");

            ++currentRow;
            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            _worksheetManager.MergeRangeAndSetValue(workRange, "Firma y Postfirma Segundo Comandante de (Unidad)");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            _worksheetManager.SetRangeFontSize(workRange, 8);
            _worksheetManager.SetRangeFontName(workRange, "Arial");

            return currentRow;
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
            var equipmentAndExplosivesEnd =
                MakeSpecialEquipmentAndExplosivesInfo(workSheet, format, weaponAndAmmunitionEnd + 3);

            var worksheetFooterInfoEnd = MakeWorksheetFooterInfo(workSheet, equipmentAndExplosivesEnd + 1);

            _worksheetManager.SetRangeOutsideBorder(workSheet.Range($"A1:M{worksheetFooterInfoEnd + 2}"),
                XLBorderStyleValues.Medium);

            var memoryStream = new MemoryStream();
            workBook.SaveAs(memoryStream);

            return memoryStream;
        }
    }
}
