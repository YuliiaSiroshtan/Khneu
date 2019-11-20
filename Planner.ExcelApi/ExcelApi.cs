using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace Planner.ExcelApi
{
    public class ExcelApi
    {
        private readonly Application _excelApp;
        private readonly Workbook _workBook;
        private Worksheet _workSheet;

        public int Count { get; }

        public ExcelApi(string path, int sheet)
        {
            _excelApp = new Application
            {
                Visible = false,
                DisplayAlerts = false
            };

            _workBook = _excelApp.Workbooks.Open(path,
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
            => _workSheet.Range[cell1, cell2].Value[XlRangeValueDataType.xlRangeValueDefault] as object[,];

        public void WriteCell(int row, int column, string data)
            => _workSheet.Cells[row, column] = data;

        public void WriteRange(string cell1, string cell2, IEnumerable<string> data)
            => _workSheet.Range[cell1, cell2].Value = data.ToArray();

        public void SaveCopyAs(string path) 
            => _workBook.SaveCopyAs(path);

        public void Close()
        {
            _excelApp.Workbooks.Close();
            _excelApp.Quit();

            Marshal.ReleaseComObject(_workSheet);
            Marshal.ReleaseComObject(_workBook);
            Marshal.ReleaseComObject(_excelApp);
        }

        public void ChangeSheet(int sheet) 
            => _workSheet = _workBook.Sheets[sheet];

        public static void KillExcelProcesses()
        {
            var processes = Process.GetProcessesByName("EXCEL");
            foreach (var process in processes)
            {
                if (process.MainWindowTitle.Length == 0)
                {
                    process.Kill();
                }
            }
        }
    }
}


