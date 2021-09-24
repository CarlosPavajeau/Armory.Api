using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Armory.Formats.AssignedWeaponMagazineFormats.Domain;
using Armory.Formats.Shared.Constants;
using Armory.Formats.Shared.Domain;
using Armory.Shared.Domain.ClosedXML;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.Generate
{
    public class AssignedWeaponMagazineFormatGenerator
    {
        private readonly IHostingEnvironment _environment;
        private readonly IWorksheetManager _worksheetManager;

        public AssignedWeaponMagazineFormatGenerator(IHostingEnvironment environment,
            IWorksheetManager worksheetManager)
        {
            _environment = environment;
            _worksheetManager = worksheetManager;
        }

        private void MakeWorksheetHeader(IXLWorksheet worksheet, AssignedWeaponMagazineFormat format)
        {
            _worksheetManager.SetRowsHeight(worksheet.Rows(1, 3), 33);
            _worksheetManager.SetColumnsWidth(worksheet.Columns("A:P"), 17);
            _worksheetManager.SetCommonRangeStyles(worksheet.Range("A1:P3"));
            worksheet.Column("A").Width = 9;

            var imagePath = Path.Combine(_environment.ContentRootPath, "wwwroot/shield.png");
            if (File.Exists(imagePath))
            {
                worksheet.Range("A1:B3").Merge();
                const int columnWidth = 25 * 7 + 12; /*To convert colum width in pixel unit*/
                var columnHeight = (int)XLHelper.GetPxFromPt(99);
                const int imageWidth = 20 * 7 + 12;
                var imageHeight = (int)XLHelper.GetPxFromPt(90);

                worksheet.AddPicture(imagePath)
                    .MoveTo(worksheet.Cell("A1"),
                        new Point((columnWidth - imageWidth) / 2, (columnHeight - imageHeight) / 2))
                    .WithSize(imageWidth, imageHeight);
            }

            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("C1:N1"), FormatConstants.FormatTitle);
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("C2:N3"),
                FormatConstants.AssignedWeaponMagazineFormatName);

            worksheet.Cell("O1").Value = "Código";
            worksheet.Cell("O2").Value = "Versión";
            worksheet.Cell("O3").Value = "Vigencia";

            worksheet.Cell("P1").Value = "GA-JELOG-FR-198";
            worksheet.Cell("P1").Style.Font.FontSize = 10;
            worksheet.Cell("P2").Value = 3;
            worksheet.Cell("P3").Value = format.Validity.ToString("d");
        }

        private void MakeWorksheetMainInfo(IXLWorksheet worksheet, AssignedWeaponMagazineFormat format)
        {
            _worksheetManager.SetRangeFontBold(worksheet.Range("A5:P9"), true);
            _worksheetManager.SetRangeFontSize(worksheet.Range("A5:P9"), 12);

            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A5:D5"), "UNIDAD: GRUPO AÉREO DEL CARIBE");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("N5:P5"), $"Formato No. {format.Code}");

            var warehouse = format.Warehouse == Warehouse.Air ? "AÉREO" : "TERRESTRE";
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A7:F7"), $"ALMACÉN DE ARMAMENTO: {warehouse}");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("J7:O7"),
                $"DEPENDENCIA O ESCUADRON: {format.Squad.Name}");
            _worksheetManager.MergeRangeAndSetValue(worksheet.Range("A9:D9"), $"FECHA: {format.Date:d}");
        }

        private void MakeAssignedWeaponMagazineFormatItemsHeader(IXLWorksheet worksheet)
        {
            _worksheetManager.SetCommonRangeStyles(worksheet.Range("A11:P11"));
            _worksheetManager.SetRangeFillBackgroundColor(worksheet.Range("A11:P11"), FormatConstants.HeaderColor);
            _worksheetManager.SetRangeFontSize(worksheet.Range("A11:P11"), 6);
            worksheet.Row(11).Height = 25;

            worksheet.Range("D11:F11").Merge();
            worksheet.Range("O11:P11").Merge();

            worksheet.Cell("A11").Value = FormatConstants.AssignedWeaponMagazineFormatItemsHeader[0];
            worksheet.Cell("B11").Value = FormatConstants.AssignedWeaponMagazineFormatItemsHeader[1];
            worksheet.Cell("C11").Value = FormatConstants.AssignedWeaponMagazineFormatItemsHeader[2];
            worksheet.Range("D11:F11").Value = FormatConstants.AssignedWeaponMagazineFormatItemsHeader[3];

            _worksheetManager.SetRangeValues(worksheet.Range("G11:N11"),
                FormatConstants.AssignedWeaponMagazineFormatItemsHeader.ToList().GetRange(4, 8));

            worksheet.Range("O11:P11").Value = FormatConstants.AssignedWeaponMagazineFormatItemsHeader.Last();

            worksheet.Cell("B11").Style.Alignment.WrapText = true;
            worksheet.Cell("I11").Style.Alignment.WrapText = true;
            worksheet.Cell("L11").Style.Alignment.WrapText = true;
            worksheet.Cell("M11").Style.Alignment.WrapText = true;
            worksheet.Cell("N11").Style.Alignment.WrapText = true;
        }

        private int MakeAssignedWeaponMagazineFormatItemsInfo(IXLWorksheet worksheet,
            AssignedWeaponMagazineFormat format)
        {
            const int start = 12;

            for (var i = 0; i < format.Records.Count; i++)
            {
                var record = format.Records.ElementAt(i);

                _worksheetManager.SetRangeValues(worksheet.Range($"A{start + i}:C{start + i}"), new List<string>
                {
                    (i + 1).ToString(),
                    "GACAR",
                    record.Troop.Degree.Name
                });

                worksheet.Range($"D{start + i}:F{start + i}").Merge();
                worksheet.Range($"D{start + i}:F{start + i}").Value =
                    $"{record.Troop.FirstName} {record.Troop.SecondName} {record.Troop.LastName} {record.Troop.SecondLastName}";

                _worksheetManager.SetRangeValues(worksheet.Range($"G{start + i}:N{start + i}"),
                    new List<string>
                    {
                        record.Weapon.Type,
                        record.Weapon.Series,
                        record.Weapon.NumberOfProviders.ToString(),
                        record.AmmunitionQuantity.ToString(),
                        record.AmmunitionLot,
                        record.SafetyCartridge ? "SI" : "NO",
                        record.VerifiedInPhysical ? "SI" : "NO",
                        record.Novelty ? "SI" : "NO"
                    });

                worksheet.Range($"O{start + i}:P{start + i}").Merge();
                worksheet.Range($"O{start + i}:P{start + i}").Value = record.Observations;
            }

            var workedRange = worksheet.Range($"A{start}:P{start + format.Records.Count - 1}");
            _worksheetManager.SetRangeBorders(workedRange, XLBorderStyleValues.Thin);
            _worksheetManager.SetRangeFontName(workedRange, "Arial");
            _worksheetManager.SetRangeAlignment(workedRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            _worksheetManager.SetRangeFontSize(workedRange, 10);

            return start + format.Records.Count;
        }

        private int MakeWorksheetComments(IXLWorksheet worksheet,
            AssignedWeaponMagazineFormat format, int previousEnd)
        {
            var currentRow = previousEnd + 1;
            var workRange = worksheet.Range($"A{currentRow}:P{currentRow + 3}");
            _worksheetManager.MergeRangeAndSetValue(workRange, $"COMENTARIOS: {format.Comments}");
            workRange.Style.Alignment.WrapText = true;
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Left,
                XLAlignmentVerticalValues.Top);

            return currentRow + 3;
        }

        private int MakeWorksheetFooterInfo(IXLWorksheet worksheet, int previousEnd)
        {
            var currentRow = previousEnd + 3;

            var workRange = worksheet.Range($"A{currentRow}:E{currentRow}");
            _worksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombres y  Apellidos");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;

            workRange = worksheet.Range($"M{currentRow}:P{currentRow}");
            _worksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombres y  Apellidos");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ++currentRow;

            workRange = worksheet.Range($"A{currentRow}:E{currentRow}");
            _worksheetManager.MergeRangeAndSetValue(workRange, "Firma y Postfirma Jefe de  Almacén y/o Bodega");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);

            workRange = worksheet.Range($"M{currentRow}:P{currentRow}");
            _worksheetManager.MergeRangeAndSetValue(workRange, "Firma y Postfirma de quien elabora la Revista");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            ++currentRow;

            workRange = worksheet.Range($"M{currentRow}:P{currentRow}");
            _worksheetManager.MergeRangeAndSetValue(workRange, "Dependencia que representa");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            ++currentRow;

            workRange = worksheet.Range($"F{currentRow}:K{currentRow}");
            _worksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombre y Apellidos");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            currentRow += 2;

            workRange = worksheet.Range($"F{currentRow}:K{currentRow}");
            _worksheetManager.MergeRangeAndSetValue(workRange,
                "Firma y Postfirma Cdte. Grupo / Escuadrón o quien haga sus veces.");
            _worksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            ++currentRow;

            workRange = worksheet.Range($"A{previousEnd}:P{currentRow}");
            _worksheetManager.SetRangeFontName(workRange, "Arial");
            _worksheetManager.SetRangeFontSize(workRange, 9);

            return currentRow;
        }

        public MemoryStream Generate(AssignedWeaponMagazineFormat format)
        {
            var workBook = new XLWorkbook();
            var workSheet = workBook.AddWorksheet(format.Code);

            MakeWorksheetHeader(workSheet, format);
            MakeWorksheetMainInfo(workSheet, format);
            MakeAssignedWeaponMagazineFormatItemsHeader(workSheet);
            var itemsEnd = MakeAssignedWeaponMagazineFormatItemsInfo(workSheet, format);
            var commentsEnd = MakeWorksheetComments(workSheet, format, itemsEnd);
            var footerEnd = MakeWorksheetFooterInfo(workSheet, commentsEnd);

            _worksheetManager.SetRangeOutsideBorder(workSheet.Range($"A1:P{footerEnd + 2}"),
                XLBorderStyleValues.Medium);

            var memoryStream = new MemoryStream();
            workBook.SaveAs(memoryStream);

            return memoryStream;
        }
    }
}
