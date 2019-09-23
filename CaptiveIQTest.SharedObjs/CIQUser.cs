using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaptiveIQTest.SharedObjs
{
    [DynamoDBTable("CIQUsers")]
    public class CIQUser
    {
        [DynamoDBHashKey]
        public string Id { get; set; }

        public List<ColumnData> Columns { get; set; } = new List<ColumnData>();

        public CellData GetCell(char colChar, int row)
        {
            try
            {
                var column = this.Columns.First(x => x.ColumnLetter == colChar);
                return column.CellDatas[row];
            }
            catch (Exception e)
            {
                return new CellData();
            }
        }
    }
}
