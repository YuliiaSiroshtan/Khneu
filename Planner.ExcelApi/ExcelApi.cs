using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace Planner.ExcelApi
{
    public class ExcelApi : IExcelApi
    {
        private readonly ExcelPackage _package;

        private ExcelWorksheet _worksheet;

        public ExcelApi(FileInfo fileInfo, int sheet)
        {
            this._package = new ExcelPackage(fileInfo);
            this._worksheet = this._package.Workbook.Worksheets[sheet];
            this.Count = this._worksheet.Dimension.Rows;
        }

        public int Count { get; }

        public object[,] ReadRange(string range) => this._worksheet.Cells[range].Value as object[,];

        public void WriteRange(string range, IEnumerable<string> data) => this._worksheet.Cells[range].Value = data;

        public void WriteCell(string cell, string data) => this._worksheet.Cells[cell].Value = data;

        public void ChangeSheet(int sheet) => this._worksheet = this._package.Workbook.Worksheets[sheet];

        public void SaveAs(string path) => this._package.SaveAs(new FileInfo(path));

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            this._package?.Dispose();
            this._worksheet?.Dispose();
        }
    }
}