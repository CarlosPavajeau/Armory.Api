using System.Collections.Generic;
using System.IO;
using System.Linq;
using Armory.Formats.AssignedWeaponMagazineFormats.Domain;
using Armory.Formats.Shared.Application.Generate;
using Armory.Formats.Shared.Constants;
using Armory.Formats.Shared.Domain;
using Armory.Shared.Domain.ClosedXML;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.Generate
{
    public class AssignedWeaponMagazineFormatGenerator : FormatGenerator
    {
        public AssignedWeaponMagazineFormatGenerator(IHostingEnvironment environment,
            IWorksheetManager worksheetManager) : base(environment, worksheetManager)
        {
        }

        private void MakeWorksheetMainInfo(IXLWorksheet worksheet, AssignedWeaponMagazineFormat format)
        {
            WorksheetManager.SetRangeFontBold(worksheet.Range("A5:P9"), true);
            WorksheetManager.SetRangeFontSize(worksheet.Range("A5:P9"), 12);

            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A5:D5"), "UNIDAD: GRUPO AÉREO DEL CARIBE");
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("N5:P5"), $"Formato No. {format.Code}");

            var warehouse = format.Warehouse == Warehouse.Air ? "AÉREO" : "TERRESTRE";
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A7:F7"), $"ALMACÉN DE ARMAMENTO: {warehouse}");
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("J7:O7"),
                $"DEPENDENCIA O ESCUADRON: {format.Squad.Name}");
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range("A9:D9"), $"FECHA: {format.Date:d}");
        }

        private void MakeAssignedWeaponMagazineFormatItemsHeader(IXLWorksheet worksheet)
        {
            WorksheetManager.SetCommonRangeStyles(worksheet.Range("A11:P11"));
            WorksheetManager.SetRangeFillBackgroundColor(worksheet.Range("A11:P11"), FormatConstants.HeaderColor);
            WorksheetManager.SetRangeFontSize(worksheet.Range("A11:P11"), 6);
            worksheet.Row(11).Height = 25;

            worksheet.Range("D11:F11").Merge();
            worksheet.Range("O11:P11").Merge();

            worksheet.Cell("A11").Value = FormatConstants.AssignedWeaponMagazineFormatItemsHeader[0];
            worksheet.Cell("B11").Value = FormatConstants.AssignedWeaponMagazineFormatItemsHeader[1];
            worksheet.Cell("C11").Value = FormatConstants.AssignedWeaponMagazineFormatItemsHeader[2];
            worksheet.Range("D11:F11").Value = FormatConstants.AssignedWeaponMagazineFormatItemsHeader[3];

            WorksheetManager.SetRangeValues(worksheet.Range("G11:N11"),
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

                WorksheetManager.SetRangeValues(worksheet.Range($"A{start + i}:C{start + i}"), new List<string>
                {
                    (i + 1).ToString(),
                    format.SquadCode,
                    record.Troop.Degree.Name
                });

                worksheet.Range($"D{start + i}:F{start + i}").Merge();
                worksheet.Range($"D{start + i}:F{start + i}").Value =
                    $"{record.Troop.FirstName} {record.Troop.SecondName} {record.Troop.LastName} {record.Troop.SecondLastName}";

                WorksheetManager.SetRangeValues(worksheet.Range($"G{start + i}:N{start + i}"),
                    new List<string>
                    {
                        record.Weapon.Type,
                        record.Weapon.Serial,
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

            var endRange = format.Records.Count == 0 ? 1 : format.Records.Count;
            var workedRange = worksheet.Range($"A{start}:P{start + endRange - 1}");
            WorksheetManager.SetRangeBorders(workedRange, XLBorderStyleValues.Thin);
            WorksheetManager.SetRangeFontName(workedRange, "Arial");
            WorksheetManager.SetRangeAlignment(workedRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            WorksheetManager.SetRangeFontSize(workedRange, 10);

            return start + format.Records.Count;
        }

        private int MakeWorksheetComments(IXLWorksheet worksheet,
            AssignedWeaponMagazineFormat format, int previousEnd)
        {
            var currentRow = previousEnd + 1;
            var workRange = worksheet.Range($"A{currentRow}:P{currentRow + 3}");
            WorksheetManager.MergeRangeAndSetValue(workRange, $"COMENTARIOS: {format.Comments}");
            workRange.Style.Alignment.WrapText = true;
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Left,
                XLAlignmentVerticalValues.Top);

            return currentRow + 3;
        }

        private int MakeWorksheetFooterInfo(IXLWorksheet worksheet, int previousEnd)
        {
            var currentRow = previousEnd + 3;

            var workRange = worksheet.Range($"A{currentRow}:E{currentRow}");
            WorksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombres y  Apellidos");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;

            workRange = worksheet.Range($"M{currentRow}:P{currentRow}");
            WorksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombres y  Apellidos");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ++currentRow;

            workRange = worksheet.Range($"A{currentRow}:E{currentRow}");
            WorksheetManager.MergeRangeAndSetValue(workRange, "Firma y Postfirma Jefe de  Almacén y/o Bodega");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);

            workRange = worksheet.Range($"M{currentRow}:P{currentRow}");
            WorksheetManager.MergeRangeAndSetValue(workRange, "Firma y Postfirma de quien elabora la Revista");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            ++currentRow;

            workRange = worksheet.Range($"M{currentRow}:P{currentRow}");
            WorksheetManager.MergeRangeAndSetValue(workRange, "Dependencia que representa");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            ++currentRow;

            workRange = worksheet.Range($"F{currentRow}:K{currentRow}");
            WorksheetManager.MergeRangeAndSetValue(workRange, "Grado - Nombre y Apellidos");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            workRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            currentRow += 2;

            workRange = worksheet.Range($"F{currentRow}:K{currentRow}");
            WorksheetManager.MergeRangeAndSetValue(workRange,
                "Firma y Postfirma Cdte. Grupo / Escuadrón o quien haga sus veces.");
            WorksheetManager.SetRangeAlignment(workRange, XLAlignmentHorizontalValues.Center,
                XLAlignmentVerticalValues.Center);
            ++currentRow;

            workRange = worksheet.Range($"A{previousEnd}:P{currentRow}");
            WorksheetManager.SetRangeFontName(workRange, "Arial");
            WorksheetManager.SetRangeFontSize(workRange, 9);

            return currentRow;
        }

        public MemoryStream Generate(AssignedWeaponMagazineFormat format)
        {
            var workBook = new XLWorkbook();
            var workSheet = workBook.AddWorksheet(format.Code);

            MakeFormatHeader(workSheet, "P");
            MakeFormatHeaderTitleAndName(workSheet, "N", FormatConstants.AssignedWeaponMagazineFormatName);
            MakeFormatHeaderInfo(workSheet, "O", "P", "GA-JELOG-FR-198", 3,
                format.Validity);
            MakeWorksheetMainInfo(workSheet, format);
            MakeAssignedWeaponMagazineFormatItemsHeader(workSheet);
            var itemsEnd = MakeAssignedWeaponMagazineFormatItemsInfo(workSheet, format);
            var commentsEnd = MakeWorksheetComments(workSheet, format, itemsEnd);
            var footerEnd = MakeWorksheetFooterInfo(workSheet, commentsEnd);

            WorksheetManager.SetRangeOutsideBorder(workSheet.Range($"A1:P{footerEnd + 2}"),
                XLBorderStyleValues.Medium);

            var memoryStream = new MemoryStream();
            workBook.SaveAs(memoryStream);

            return memoryStream;
        }
    }
}
