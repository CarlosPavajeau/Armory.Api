using System;
using System.Collections.Generic;
using System.Linq;
using Armory.Shared.Domain.ClosedXML;
using ClosedXML.Excel;

namespace Armory.Shared.Infrastructure.ClosedXML
{
    public class WorksheetManager : IWorksheetManager
    {
        public void SetRowsHeight(IXLRows rows, float height)
        {
            rows.Height = height;
        }

        public void SetColumnsWidth(IXLColumns columns, float width)
        {
            columns.Width = width;
        }

        public void SetCommonRangeStyles(IXLRange range)
        {
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Hair;
            range.Style.Border.InsideBorder = XLBorderStyleValues.Hair;
            range.Style.Font.FontSize = 12;
            range.Style.Font.FontName = "Arial";
            SetRangeFontBold(range, true);
            range.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            range.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        }

        public void MergeRange(IXLRange range)
        {
            range.Merge();
        }

        public void MergeRangeAndSetValue<T>(IXLRange range, T value)
        {
            MergeRange(range);
            range.Value = value;
        }

        public void SetRangeFontBold(IXLRange range, bool bold)
        {
            range.Style.Font.Bold = bold;
        }

        public void SetRangeFontSize(IXLRange range, double fontSize)
        {
            range.Style.Font.FontSize = fontSize;
        }

        public void SetRangeFillBackgroundColor(IXLRange range, XLColor color)
        {
            range.Style.Fill.BackgroundColor = color;
        }

        public void SetRangeValues(IXLRange range, List<string> values)
        {
            if (range.Cells().Count() != values.Count)
                throw new ArgumentException(
                    $"The size of the ranges and the values to be set do not match. Ranges: {range.Cells().Count()}, Values: {values.Count}");

            var index = 0;
            foreach (var cell in range.Cells())
            {
                cell.Value = values[index];
                ++index;
            }
        }
    }
}
