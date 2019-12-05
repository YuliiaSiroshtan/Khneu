using System;
using System.Collections.Generic;

namespace Planner.ExcelApi
{
    public interface IExcelApi : IDisposable
    {
        int Count { get; }

        object[,] ReadRange(string range);

        void WriteRange(string range, IEnumerable<string> data);

        void WriteCell(string cell, string data);

        void ChangeSheet(int sheet);

        void SaveAs(string path);
    }
}