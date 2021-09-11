using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Armory.Formats.Shared.Constants;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;
using Armory.Shared.Domain.ClosedXML;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Generate
{
    public class WarMaterialDeliveryCertificateFormatGenerator
    {
        private readonly IHostingEnvironment _environment;
        private readonly IWorksheetManager _worksheetManager;

        public WarMaterialDeliveryCertificateFormatGenerator(IHostingEnvironment environment,
            IWorksheetManager worksheetManager)
        {
            _environment = environment;
            _worksheetManager = worksheetManager;
        }

        private void MakeWorksheetHeader(IXLWorksheet worksheet, WarMaterialDeliveryCertificateFormat format)
        {
            _worksheetManager.SetRowsHeight(worksheet.Rows(1, 3), 33);
            _worksheetManager.SetColumnsWidth(worksheet.Columns("B:M"), 17);
            worksheet.Column("A").Width = 4;
            _worksheetManager.SetCommonRangeStyles(worksheet.Range("A1:M3"));

            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A1:B3"), "ArmoryImage");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("C1:K1"), FormatConstants.FormatTitle);
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("C2:K3"),
                FormatConstants.WarMaterialDeliveryCertificateFormatName);

            worksheet.Cell("L1").Value = "Código";
            worksheet.Cell("L2").Value = "Versión";
            worksheet.Cell("L3").Value = "Vigencia";

            worksheet.Cell("M1").Value = format.Code;
            worksheet.Cell("M2").Value = 1;
            worksheet.Cell("M3").Value = format.Validity.ToString("d");
        }

        private void MakeWorksheetMainInfo(IXLWorksheet worksheet, WarMaterialDeliveryCertificateFormat format)
        {
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("K5:M5"), $"FORMATO ACTA No. {format.Id}");

            _worksheetManager.SetRangeFontBold(worksheet.Range("K5:M5"), true);
            _worksheetManager.SetRangeFontBold(worksheet.Range("A6:M9"), true);
            _worksheetManager.SetRangeFontSize(worksheet.Range("A6:M9"), 12);

            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A6:F6"),
                $"Lugar y fecha: {format.Place}, {format.Date:d}");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A7:F7"),
                $"Unidad: {format.Unit.Code} - {format.Unit.Name}");

            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A9:F9"),
                $"ENTREGA A: {format.Applicant.Id} - {format.Applicant.FullName}");
        }

        private void MakeWeaponsAndAmmunitionHeader(IXLWorksheet worksheet)
        {
            _worksheetManager.SetCommonRangeStyles(worksheet.Range("A12:M13"));
            _worksheetManager.SetRangeFillBackgroundColor(worksheet.Range("A12:M13"), FormatConstants.HeaderColor);

            worksheet.Row(13).Height = 25;
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A12:A13"), "ÍTEM");
            _worksheetManager.SetRangeFontSize(worksheet.Range("A12:A13"), 8);

            _worksheetManager.SetCommonRangeStyles(worksheet.Range("B12:M13"));
            _worksheetManager.SetRangeFontSize(worksheet.Range("B13:M13"), 9);
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("B12:H12"), "ARMAMENTO");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("I12:M12"), "MUNICIÓN");

            _worksheetManager.SetRangeValues(worksheet.Range("B13:M13"), FormatConstants.WeaponsAndAmmunitionHeader);
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
                    format.WarMaterialDeliveryCertificateFormatAmmunition.First(x =>
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
            var workedRange = worksheet.Range($"A14:M{start + maxNumOfElements - 1}");
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
            WarMaterialDeliveryCertificateFormat format, int previousEnd)
        {
            for (var i = 0; i < format.Equipments.Count; i++)
            {
                var equipment = format.Equipments.ElementAt(i);
                var equipmentFormat =
                    format.WarMaterialDeliveryCertificateFormatEquipments.First(x =>
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
                    format.WarMaterialDeliveryCertificateFormatExplosives.First(x =>
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

            var workRange = worksheet.Range($"D{currentRow}:D{currentRow + 9}");
            _worksheetManager.SetRangeOutsideBorder(workRange, XLBorderStyleValues.Medium);
            worksheet.Cell($"D{currentRow + 10}").Value = "HUELLA RESPONSABLE";
            worksheet.Cell($"D{currentRow + 10}").Style.Font.FontSize = 8;
            worksheet.Cell($"D{currentRow + 10}").Style.Font.FontName = "Arial";

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            _worksheetManager.MergeRangeAndSetValue(workRange,
                "Firma y Postfirma Comandante del Cadete, Alumno y/o Soldado");
            ++currentRow;

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Hair;
            _worksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombres y  Apellidos");
            ++currentRow;

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            _worksheetManager.MergeRangeAndSetValue(workRange, "Cargo");
            ++currentRow;

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            _worksheetManager.MergeRangeAndSetValue(workRange, "Dependencia");

            workRange = worksheet.Range($"J{currentRow}:L{currentRow}");
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Medium;
            currentRow += 5;

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            _worksheetManager.MergeRangeAndSetValue(workRange,
                "Firma y Postfirma Cadete, Alumno y/o Soldado");
            ++currentRow;

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Hair;
            _worksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombres y  Apellidos");
            ++currentRow;

            workRange = worksheet.Range($"F{currentRow}:H{currentRow}");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            _worksheetManager.MergeRangeAndSetValue(workRange, "Cargo");

            workRange = worksheet.Range($"J{currentRow}:L{currentRow}");
            _worksheetManager.MergeRangeAndSetValue(workRange, "IMPRONTA DEL ARMA");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Medium;
            ++currentRow;

            workRange = worksheet.Range($"A{previousEnd}:M{currentRow}");
            _worksheetManager.SetRangeFontSize(workRange, 8);
            _worksheetManager.SetRangeFontName(workRange, "Arial");

            return currentRow;
        }

        public MemoryStream Generate(WarMaterialDeliveryCertificateFormat format)
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
