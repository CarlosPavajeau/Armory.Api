using ClosedXML.Excel;

namespace Armory.Shared.Domain.ClosedXML
{
    public interface IWorksheetManager
    {
        void SetRowsHeight(IXLRows rows, float height);
        void SetColumnsWidth(IXLColumns columns, float width);
        void SetCommonRangeStyles(IXLRange range);
        void MergeRange(IXLRange range);
        void MergeRangeAndSetValue<T>(IXLRange range, T value);

        void SetRangeFontBold(IXLRange range, bool bold);
    }
}
