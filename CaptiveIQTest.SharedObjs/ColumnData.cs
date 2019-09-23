using System;
using System.Collections.Generic;
using System.Text;

namespace CaptiveIQTest.SharedObjs
{
    public class ColumnData
    {
        public char ColumnLetter { get; set; }

        public List<CellData> CellDatas = new List<CellData>();
    }
}
