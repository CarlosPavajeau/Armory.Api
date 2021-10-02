using System;
using System.Drawing;
using System.IO;
using Armory.Formats.Shared.Constants;
using Armory.Shared.Domain.ClosedXML;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;

namespace Armory.Formats.Shared.Application.Generate
{
    public class FormatGenerator
    {
        private readonly IHostingEnvironment _environment;
        protected readonly IWorksheetManager WorksheetManager;

        protected FormatGenerator(IHostingEnvironment environment, IWorksheetManager worksheetManager)
        {
            _environment = environment;
            WorksheetManager = worksheetManager;
        }

        protected void MakeFormatHeader(IXLWorksheet worksheet, string endColumn)
        {
            WorksheetManager.SetRowsHeight(worksheet.Rows(1, 3), 33);
            WorksheetManager.SetColumnsWidth(worksheet.Columns($"A:{endColumn}"), 17);
            WorksheetManager.SetCommonRangeStyles(worksheet.Range($"A1:{endColumn}3"));
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
        }

        protected void MakeFormatHeaderTitleAndName(IXLWorksheet worksheet, string endColumn, string name)
        {
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range($"C1:{endColumn}1"), FormatConstants.FormatTitle);
            WorksheetManager.MergeRangeAndSetValue(worksheet.Range($"C2:{endColumn}3"), name);
        }

        protected static void MakeFormatHeaderInfo(IXLWorksheet worksheet, string namesColumn, string valuesColumn,
            string code, int version, DateTime validity)
        {
            worksheet.Cell($"{namesColumn}1").Value = "Código";
            worksheet.Cell($"{namesColumn}2").Value = "Versión";
            worksheet.Cell($"{namesColumn}3").Value = "Vigencia";

            worksheet.Cell($"{valuesColumn}1").Value = code;
            worksheet.Cell($"{valuesColumn}1").Style.Font.FontSize = 9;
            worksheet.Cell($"{valuesColumn}2").Value = version;
            worksheet.Cell($"{valuesColumn}3").Value = validity.ToString("d");
        }
    }
}
