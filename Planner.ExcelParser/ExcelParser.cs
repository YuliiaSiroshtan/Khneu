using Microsoft.Office.Interop.Excel;
using System;
using System.Runtime.InteropServices;

namespace Planner.ExcelParser
{
    public class ExcelParser
    {
        private readonly Application _excelApp;
        private readonly Workbook _workBook;
        private readonly Worksheet _workSheet;

        public int Count { get; }
        public ExcelParser(string fileName, int sheet)
        {
            _excelApp = new Application();
            _workBook = _excelApp.Workbooks.Open(fileName,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing);
            _workSheet = _workBook.Sheets[sheet];
            Count = _workSheet.Cells.Find("*", Type.Missing,
                Type.Missing, Type.Missing,
                XlSearchOrder.xlByRows, XlSearchDirection.xlPrevious,
                false, Type.Missing, Type.Missing).Row;
        }

        public object[,] ReadRange(string cell1, string cell2)
        {
            var data = _workSheet.Range[cell1, cell2];

            return (object[,])data.Value[XlRangeValueDataType.xlRangeValueDefault];
        }

        public void Close()
        {
            _workBook.Close(false);
            _excelApp.Quit();

            Marshal.ReleaseComObject(_workSheet);
            Marshal.ReleaseComObject(_workBook);
            Marshal.ReleaseComObject(_excelApp);
        }
    }
}
