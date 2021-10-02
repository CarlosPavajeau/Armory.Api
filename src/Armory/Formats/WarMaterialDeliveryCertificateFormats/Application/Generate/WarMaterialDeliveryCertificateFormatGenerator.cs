using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Armory.Formats.Shared.Application.Generate;
using Armory.Formats.Shared.Constants;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;
using Armory.Shared.Domain.ClosedXML;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Generate
{
    public class WarMaterialDeliveryCertificateFormatGenerator : FormatGenerator
    {
        public WarMaterialDeliveryCertificateFormatGenerator(IHostingEnvironment environment,
            IWorksheetManager worksheetManager) : base(environment, worksheetManager)
        {
        }

        private void MakeWorksheetMainInfo(IXLWorksheet worksheet, WarMaterialDeliveryCertificateFormat format)
        {
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("K5:M5"), $"FORMATO ACTA No. {format.Code}");

            WorksheetManager.SetRangeFontBold(worksheet.Range("K5:M5"), true);
            WorksheetManager.SetRangeFontBold(worksheet.Range("A6:M9"), true);
            WorksheetManager.SetRangeFontSize(worksheet.Range("A6:M9"), 12);

            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A6:F6"),
                $"Lugar y fecha: {format.Place}, {format.Date:d}");
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A7:F7"),
                "UNIDAD: GRUPO AÉREO DEL CARIBE");

            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A9:F9"),
                "ENTREGA A: CADETE [  ] ALUMNO [  ] SOLDADO [  ]");
        }

        private void MakeWeaponsAndAmmunitionHeader(IXLWorksheet worksheet)
        {
            WorksheetManager.SetCommonRangeStyles(worksheet.Range("A12:M13"));
            WorksheetManager.SetRangeFillBackgroundColor(worksheet.Range("A12:M13"), FormatConstants.HeaderColor);

            worksheet.Row(13).Height = 25;
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A12:A13"), "ÍTEM");
            WorksheetManager.SetRangeFontSize(worksheet.Range("A12:A13"), 8);

            WorksheetManager.SetCommonRangeStyles(worksheet.Range("B12:M13"));
            WorksheetManager.SetRangeFontSize(worksheet.Range("B13:M13"), 9);
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("B12:H12"), "ARMAMENTO");
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("I12:M12"), "MUNICIÓN");

            WorksheetManager.SetRangeValues(worksheet.Range("B13:M13"), FormatConstants.WeaponsAndAmmunitionHeader);
            worksheet.Cell("M13").Style.Alignment.WrapText = true;
            worksheet.Cell("G13").Style.Alignment.WrapText = true;
            worksheet.Cell("H13").Style.Alignment.WrapText = true;
        }

        private int MakeWeaponsAndAmmunitionInfo(IXLWorksheet worksheet,
            WarMaterialDeliveryCertificateFormat format)
        {
            const int start = 14;
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
                    format.WarMaterialDeliveryCertificateFormatAmmunition.First(x =>
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
            var workedRange = worksheet.Range($"A14:M{start + maxNumOfElements - 1}");
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
            WarMaterialDeliveryCertificateFormat format, int previousEnd)
        {
            for (var i = 0; i < format.Equipments.Count; i++)
            {
                var equipment = format.Equipments.ElementAt(i);
                var equipmentFormat =
                    format.WarMaterialDeliveryCertificateFormatEquipments.First(x =>
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
                    format.WarMaterialDeliveryCertificateFormatExplosives.First(x =>
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

        private int MakeWorksheetFooterInfo(IXLWorksheet worksheet, WarMaterialDeliveryCertificateFormat format,
            int previousEnd)
        {
            var currentRow = previousEnd + 3;

            var workRange = worksheet.Range($"D{currentRow}:D{currentRow + 9}");
            WorksheetManager.SetRangeOutsideBorder(workRange, XLBorderStyleValues.Medium);
            worksheet.Cell($"D{currentRow + 10}").Value = "HUELLA RESPONSABLE";
            worksheet.Cell($"D{currentRow + 10}").Style.Font.FontSize = 8;
            worksheet.Cell($"D{currentRow + 10}").Style.Font.FontName = "Arial";

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            WorksheetManager.MergeRangeAndSetValue(workRange,
                "Firma y Postfirma Comandante del Cadete, Alumno y/o Soldado");
            workRange.Style.Font.FontColor = XLColor.Gray;
            ++currentRow;

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            WorksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombres y  Apellidos");
            ++currentRow;

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            WorksheetManager.MergeRangeAndSetValue(workRange, "Cargo");
            ++currentRow;

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            WorksheetManager.MergeRangeAndSetValue(workRange, "Dependencia");

            workRange = worksheet.Range($"J{currentRow}:L{currentRow}");
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Medium;
            currentRow += 5;

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            WorksheetManager.MergeRangeAndSetValue(workRange,
                "Firma y Postfirma Cadete, Alumno y/o Soldado");
            workRange.Style.Font.FontColor = XLColor.Gray;
            ++currentRow;

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            WorksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombres y Apellidos");
            ++currentRow;

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            WorksheetManager.MergeRangeAndSetValue(workRange, "Cargo");

            workRange = worksheet.Range($"J{currentRow}:L{currentRow}");
            WorksheetManager.MergeRangeAndSetValue(workRange, "IMPRONTA DEL ARMA");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Medium;
            ++currentRow;

            workRange = worksheet.Range($"A{previousEnd}:M{currentRow}");
            WorksheetManager.SetRangeFontSize(workRange, 8);
            WorksheetManager.SetRangeFontName(workRange, "Arial");

            return currentRow;
        }

        public MemoryStream Generate(WarMaterialDeliveryCertificateFormat format)
        {
            var workBook = new XLWorkbook();
            var workSheet = workBook.AddWorksheet(format.Code);

            MakeFormatHeader(workSheet, "M");
            MakeFormatHeaderTitleAndName(workSheet, "K", FormatConstants.WarMaterialDeliveryCertificateFormatName);
            MakeFormatHeaderInfo(workSheet, "L", "M", "GA-JES-FR-052",
                1, format.Validity);

            MakeWorksheetMainInfo(workSheet, format);
            MakeWeaponsAndAmmunitionHeader(workSheet);

            var weaponAndAmmunitionEnd = MakeWeaponsAndAmmunitionInfo(workSheet, format);
            MakeSpecialEquipmentHeader(workSheet, weaponAndAmmunitionEnd + 1);
            MakeExplosivesHeader(workSheet, weaponAndAmmunitionEnd + 1);
            var equipmentAndExplosivesEnd =
                MakeSpecialEquipmentAndExplosivesInfo(workSheet, format, weaponAndAmmunitionEnd + 3);
            var worksheetFooterInfoEnd = MakeWorksheetFooterInfo(workSheet, format, equipmentAndExplosivesEnd + 1);

            WorksheetManager.SetRangeOutsideBorder(workSheet.Range($"A1:M{worksheetFooterInfoEnd + 2}"),
                XLBorderStyleValues.Medium);

            var memoryStream = new MemoryStream();
            workBook.SaveAs(memoryStream);

            return memoryStream;
        }
    }
}
