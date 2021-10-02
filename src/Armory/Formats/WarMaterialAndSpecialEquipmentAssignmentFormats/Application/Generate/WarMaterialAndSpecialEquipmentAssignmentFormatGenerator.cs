using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Armory.Formats.Shared.Application.Generate;
using Armory.Formats.Shared.Constants;
using Armory.Formats.Shared.Domain;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Armory.Shared.Domain.ClosedXML;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Generate
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatGenerator : FormatGenerator
    {
        public WarMaterialAndSpecialEquipmentAssignmentFormatGenerator(IHostingEnvironment environment,
            IWorksheetManager worksheetManager) : base(environment, worksheetManager)
        {
        }

        private void MakeWorksheetMainInfo(IXLWorksheet worksheet,
            WarMaterialAndSpecialEquipmentAssignmentFormat format)
        {
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("K5:M5"), $"FORMATO ACTA No. {format.Code}");

            WorksheetManager.SetRangeFontBold(worksheet.Range("K5:M5"), true);
            WorksheetManager.SetRangeFontBold(worksheet.Range("A6:M17"), true);
            WorksheetManager.SetRangeFontSize(worksheet.Range("A6:M17"), 12);

            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A6:F6"),
                $"Lugar y fecha: {format.Place}, {format.Date:d}");
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A7:F7"),
                "Unidad: GRUPO AÉREO DEL CARIBE");

            var warehouse = format.Warehouse == Warehouse.Air ? "AÉREO" : "TERRESTRE";
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("H7:M7"),
                $"ALMACÉN DE ARMAMENTO: {warehouse}");
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A8:F8"),
                $"Solicitante: {format.Flight.Owner.Degree.Name}. {format.Flight.Owner.FullName}");
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A9:F9"),
                $"Dependencia: {format.Squad.Name}");

            var purpose = format.Purpose switch
            {
                Purpose.Instruction => "INSTRUCCIÓN",
                Purpose.Operations => "OPERACIONES",
                Purpose.Verification => "COMPROBACIÓN",
                _ => throw new ArgumentOutOfRangeException(
                    $"Invalid purpose value, the pass value is {format.Purpose}")
            };
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A11:F11"), $"Finalidad: {purpose}");
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("I11:M11"), $"OTROS: {format.Others}");

            var docMovement = format.DocMovement == DocMovement.Consumption ? "CONSUMO" : "DEVOLUTIVO";
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A15:F15"), $"DOC MOVIMIENTO: {docMovement}");
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A17:D17"),
                $"UBICACIÓN FÍSICA: {format.PhysicalLocation}");
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("E17:H17"),
                "(Cuando se encuentre en puntos de custodia)");
        }

        private void MakeWeaponsAndAmmunitionHeader(IXLWorksheet worksheet)
        {
            WorksheetManager.SetCommonRangeStyles(worksheet.Range("A19:M20"));
            WorksheetManager.SetRangeFillBackgroundColor(worksheet.Range("A19:M20"), FormatConstants.HeaderColor);

            worksheet.Row(20).Height = 25;
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A19:A20"), "ÍTEM");
            WorksheetManager.SetRangeFontSize(worksheet.Range("A19:A20"), 8);

            WorksheetManager.SetCommonRangeStyles(worksheet.Range("B19:M20"));
            WorksheetManager.SetRangeFontSize(worksheet.Range("B20:M20"), 9);
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("B19:H19"), "ARMAMENTO");
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("I19:M19"), "MUNICIÓN");

            WorksheetManager.SetRangeValues(worksheet.Range("B20:M20"), FormatConstants.WeaponsAndAmmunitionHeader);
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

                WorksheetManager.SetRangeValues(worksheet.Range($"A{start + i}:H{start + i}"),
                    new List<string>
                    {
                        (i + 1).ToString(),
                        weapon.Type,
                        weapon.Mark,
                        weapon.Model,
                        weapon.Caliber,
                        weapon.Serial,
                        weapon.NumberOfProviders.ToString(),
                        weapon.ProviderCapacity.ToString()
                    });
            }

            for (var i = 0; i < format.Ammunition.Count; i++)
            {
                var ammunition = format.Ammunition.ElementAt(i);
                var formatAmmunition =
                    format.WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition.First(x =>
                        x.AmmunitionLot == ammunition.Lot);

                WorksheetManager.SetRangeValues(worksheet.Range($"I{start + i}:M{start + i}"),
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
            WorksheetManager.SetRangeBorders(workedRange, XLBorderStyleValues.Thin);
            WorksheetManager.SetRangeFontName(workedRange, "Arial");
            WorksheetManager.SetRangeAlignment(workedRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);

            return start + maxNumOfElements;
        }

        private void MakeSpecialEquipmentHeader(IXLWorksheet worksheet, int start)
        {
            var headerRange = worksheet.Range($"A{start}:E{start}");
            WorksheetManager.SetCommonRangeStyles(headerRange);
            WorksheetManager.SetRangeFillBackgroundColor(headerRange, FormatConstants.HeaderColor);
            WorksheetManager.MergeRangeAndSetValue(headerRange, "EQUIPO ESPECIAL Y ACCESORIOS");

            headerRange = worksheet.Range($"A{start + 1}:E{start + 1}");
            worksheet.Row(start + 1).Height = 25;
            WorksheetManager.SetCommonRangeStyles(headerRange);
            WorksheetManager.SetRangeFontSize(headerRange, 9);
            WorksheetManager.SetRangeFillBackgroundColor(headerRange, FormatConstants.HeaderColor);
            WorksheetManager.SetRangeValues(headerRange, FormatConstants.SpecialEquipmentsHeader);
        }

        private void MakeExplosivesHeader(IXLWorksheet worksheet, int start)
        {
            var headerRange = worksheet.Range($"H{start}:M{start}");
            WorksheetManager.SetCommonRangeStyles(headerRange);
            WorksheetManager.SetRangeFillBackgroundColor(headerRange, FormatConstants.HeaderColor);
            WorksheetManager.MergeRangeAndSetValue(headerRange, "GRANADAS Y EXPLOSIVOS");

            headerRange = worksheet.Range($"H{start + 1}:M{start + 1}");
            worksheet.Row(start + 1).Height = 25;
            WorksheetManager.SetCommonRangeStyles(headerRange);
            WorksheetManager.SetRangeFontSize(headerRange, 9);
            WorksheetManager.SetRangeFillBackgroundColor(headerRange, FormatConstants.HeaderColor);
            WorksheetManager.SetRangeValues(headerRange, FormatConstants.ExplosivesHeader);
        }

        private int MakeSpecialEquipmentAndExplosivesInfo(IXLWorksheet worksheet,
            WarMaterialAndSpecialEquipmentAssignmentFormat format, int previousEnd)
        {
            for (var i = 0; i < format.Equipments.Count; i++)
            {
                var equipment = format.Equipments.ElementAt(i);
                var equipmentFormat =
                    format.WarMaterialAndSpecialEquipmentAssignmentFormatEquipments.First(x =>
                        x.EquipmentSerial == equipment.Serial);

                WorksheetManager.SetRangeValues(worksheet.Range($"A{previousEnd + i}:E{previousEnd + i}"),
                    new List<string>
                    {
                        (i + 1).ToString(),
                        equipment.Type,
                        equipment.Model,
                        equipment.Serial,
                        equipmentFormat.Quantity.ToString()
                    });
            }

            for (var i = 0; i < format.Explosives.Count; i++)
            {
                var explosive = format.Explosives.ElementAt(i);
                var explosiveFormat =
                    format.WarMaterialAndSpecialEquipmentAssignmentFormatExplosives.First(x =>
                        x.ExplosiveSerial == explosive.Serial);

                WorksheetManager.SetRangeValues(worksheet.Range($"H{previousEnd + i}:M{previousEnd + i}"),
                    new List<string>
                    {
                        explosive.Type,
                        explosive.Caliber,
                        explosive.Mark,
                        explosive.Lot,
                        explosive.Serial,
                        explosiveFormat.Quantity.ToString()
                    });
            }

            var maxNumOfElements = Math.Max(format.Explosives.Count, format.Equipments.Count);
            if (maxNumOfElements == 0) maxNumOfElements = 1;
            var workedRange = worksheet.Range($"A{previousEnd}:E{previousEnd + maxNumOfElements - 1}");
            WorksheetManager.SetRangeBorders(workedRange, XLBorderStyleValues.Thin);
            WorksheetManager.SetRangeFontName(workedRange, "Arial");
            WorksheetManager.SetRangeAlignment(workedRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);

            workedRange = worksheet.Range($"H{previousEnd}:M{previousEnd + maxNumOfElements - 1}");
            WorksheetManager.SetRangeBorders(workedRange, XLBorderStyleValues.Thin);
            WorksheetManager.SetRangeFontName(workedRange, "Arial");
            WorksheetManager.SetRangeAlignment(workedRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);

            return previousEnd + maxNumOfElements;
        }

        private int MakeWorksheetFooterInfo(IXLWorksheet worksheet, int previousEnd)
        {
            var currentRow = previousEnd + 3;

            var workRange = worksheet.Range($"A{currentRow}:C{currentRow}");
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            WorksheetManager.MergeRangeAndSetValue(workRange,
                "Grado - Nombres y Apellidos");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            WorksheetManager.SetRangeFontSize(workRange, 8);
            WorksheetManager.SetRangeFontName(workRange, "Arial");

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            WorksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombres y Apellidos");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            WorksheetManager.SetRangeFontSize(workRange, 8);
            WorksheetManager.SetRangeFontName(workRange, "Arial");

            workRange = worksheet.Range($"K{currentRow}:M{currentRow}");
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            WorksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombres y Apellidos");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            WorksheetManager.SetRangeFontSize(workRange, 8);
            WorksheetManager.SetRangeFontName(workRange, "Arial");

            ++currentRow;
            worksheet.Row(currentRow).Height = 27;

            workRange = worksheet.Range($"A{currentRow}:C{currentRow}");
            WorksheetManager.MergeRangeAndSetValue(workRange, "Firma y Postfirma Jefe de Almacén (Unidad)");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Font.FontColor = XLColor.Gray;
            WorksheetManager.SetRangeFontSize(workRange, 8);
            WorksheetManager.SetRangeFontName(workRange, "Arial");

            workRange = worksheet.Range($"K{currentRow}:M{currentRow}");
            workRange.Style.Alignment.WrapText = true;
            WorksheetManager.MergeRangeAndSetValue(workRange,
                "Firma y Postfirma Cdte. Esc. Armamento o Cdte. Grupo/Escuadron de Seguridad (Unidad)");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Font.FontColor = XLColor.Gray;
            WorksheetManager.SetRangeFontSize(workRange, 8);
            WorksheetManager.SetRangeFontName(workRange, "Arial");

            currentRow += 3;
            worksheet.Cell($"C{currentRow}").Value = "AUTORIZA:";
            worksheet.Cell($"C{currentRow}").Style.Font.Bold = true;
            worksheet.Cell($"C{currentRow}").Style.Font.FontName = "Arial";

            worksheet.Cell($"F{currentRow}").Value = "SI   [   ]";
            worksheet.Cell($"H{currentRow}").Value = "NO   [   ]";

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            WorksheetManager.SetRangeFontBold(workRange, true);
            WorksheetManager.SetRangeFontSize(workRange, 12);
            WorksheetManager.SetRangeFontName(workRange, "Arial");

            currentRow += 5;
            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            WorksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombres y Apellidos");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            WorksheetManager.SetRangeFontSize(workRange, 8);
            WorksheetManager.SetRangeFontName(workRange, "Arial");

            ++currentRow;
            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            WorksheetManager.MergeRangeAndSetValue(workRange, "Firma y Postfirma Segundo Comandante de (Unidad)");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Font.FontColor = XLColor.Gray;
            WorksheetManager.SetRangeFontSize(workRange, 8);
            WorksheetManager.SetRangeFontName(workRange, "Arial");

            return currentRow;
        }

        public MemoryStream Generate(WarMaterialAndSpecialEquipmentAssignmentFormat format)
        {
            var workBook = new XLWorkbook();
            var workSheet = workBook.AddWorksheet(format.Code);

            MakeFormatHeader(workSheet, "M");
            MakeFormatHeaderTitleAndName(workSheet, "K",
                FormatConstants.WarMaterialAndSpecialEquipmentAssignmentFormatName);
            MakeFormatHeaderInfo(workSheet, "L", "M", "GA-JELOG-FR-199", 4, format.Validity);
            MakeWorksheetMainInfo(workSheet, format);
            MakeWeaponsAndAmmunitionHeader(workSheet);

            var weaponAndAmmunitionEnd = MakeWeaponsAndAmmunitionInfo(workSheet, format);
            MakeSpecialEquipmentHeader(workSheet, weaponAndAmmunitionEnd + 1);
            MakeExplosivesHeader(workSheet, weaponAndAmmunitionEnd + 1);
            var equipmentAndExplosivesEnd =
                MakeSpecialEquipmentAndExplosivesInfo(workSheet, format, weaponAndAmmunitionEnd + 3);

            var worksheetFooterInfoEnd = MakeWorksheetFooterInfo(workSheet, equipmentAndExplosivesEnd + 1);

            WorksheetManager.SetRangeOutsideBorder(workSheet.Range($"A1:M{worksheetFooterInfoEnd + 2}"),
                XLBorderStyleValues.Medium);

            var memoryStream = new MemoryStream();
            workBook.SaveAs(memoryStream);

            return memoryStream;
        }
    }
}
