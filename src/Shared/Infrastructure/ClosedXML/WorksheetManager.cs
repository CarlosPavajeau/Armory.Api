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
    }
}
