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
            SetRangeBorders(range, XLBorderStyleValues.Hair);
            SetRangeFontSize(range, 12);
            SetRangeFontName(range, "Arial");
            SetRangeFontBold(range, true);
            SetRangeAlignment(range, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
        }

        public void SetRangeAlignment(IXLRange range, XLAlignmentHorizontalValues horizontal,
            XLAlignmentVerticalValues vertical)
        {
            range.Style.Alignment.Horizontal = horizontal;
            range.Style.Alignment.Vertical = vertical;
        }

        public void SetRangeOutsideBorder(IXLRange range, XLBorderStyleValues borderStyleValues)
        {
            range.Style.Border.OutsideBorder = borderStyleValues;
        }

        public void SetRangeInsideBorder(IXLRange range, XLBorderStyleValues borderStyleValues)
        {
            range.Style.Border.InsideBorder = borderStyleValues;
        }

        public void SetRangeBorders(IXLRange range, XLBorderStyleValues borderStyleValues)
        {
            SetRangeOutsideBorder(range, borderStyleValues);
            SetRangeInsideBorder(range, borderStyleValues);
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

        public void SetRangeFontName(IXLRange range, string fontName)
        {
            range.Style.Font.FontName = fontName;
        }

        public void SetRangeFillBackgroundColor(IXLRange range, XLColor color)
        {
            range.Style.Fill.BackgroundColor = color;
        }

        public void SetRangeValues(IXLRange range, IReadOnlyCollection<string> values)
        {
            if (range.Cells().Count() != values.Count)
            {
                throw new ArgumentException(
                    $"The size of the ranges and the values to be set do not match. Ranges: {range.Cells().Count()}, Values: {values.Count}");
            }

            var index = 0;
            foreach (var cell in range.Cells())
            {
                cell.Value = values.ElementAt(index);
                ++index;
            }
        }

        private static void MergeRange(IXLRangeBase range)
        {
            range.Merge();
        }
    }
}
