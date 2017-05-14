using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableExtentions
{
    public static class MyClass
    {
        public static void AddRow(this DataTable table, string cv1, string cv2)
        {
            var newRow = table.NewRow();
            newRow[0] = cv1;
            newRow[1] = cv2;
            table.Rows.Add(newRow);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            DataColumn col1 =table.Columns.Add("first");
            DataColumn col2 = table.Columns.Add("second");
            table.Constraints.Add("constraint", new[] { col1, col2 }, false);
            table.AddRow("uniq", "uniq");
            //table.AddRow("uniq", "uniq");//false
            table.AddRow("uniq", "unique");//true

        }
    }
}
