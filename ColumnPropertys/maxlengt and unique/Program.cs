using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxlengt_and_unique
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            DataColumn col = table.Columns.Add("coll");
            //col.MaxLength = 4;
            col.Unique = true;
            DataRow row = table.NewRow();
            row[0] = "shff";
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = "shff";
            table.Rows.Add(row);
            Console.WriteLine(table.Rows[0][0]);

        }
    }
}
