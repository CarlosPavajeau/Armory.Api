using System.Collections.Generic;
using ClosedXML.Excel;

namespace Armory.Shared.Domain.ClosedXML
{
    public interface IWorksheetManager
    {
        void SetRowsHeight(IXLRows rows, float height);
        void SetColumnsWidth(IXLColumns columns, float width);
        void SetCommonRangeStyles(IXLRange range);

        void SetRangeAlignment(IXLRange range, XLAlignmentHorizontalValues horizontal,
            XLAlignmentVerticalValues vertical);

        void SetRangeOutsideBorder(IXLRange range, XLBorderStyleValues borderStyleValues);
        void SetRangeInsideBorder(IXLRange range, XLBorderStyleValues borderStyleValues);
        void SetRangeBorders(IXLRange range, XLBorderStyleValues borderStyleValues);
        void MergeRangeAndSetValue<T>(IXLRange range, T value);

        void SetRangeFontBold(IXLRange range, bool bold);
        void SetRangeFontSize(IXLRange range, double fontSize);
        void SetRangeFontName(IXLRange range, string fontName);
        void SetRangeFillBackgroundColor(IXLRange range, XLColor color);
        void SetRangeValues(IXLRange range, IReadOnlyCollection<string> values);
    }
}
