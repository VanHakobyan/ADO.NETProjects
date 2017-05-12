using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRows
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("name"));
            table.Columns.Add("age", typeof(int));
            DataRow row = table.NewRow();
            row["name"] = "Van";
            row["age"] = 21;
            table.Rows.Add(row);
            foreach (DataRow R in table.Rows)
            {
                foreach (DataColumn C in table.Columns)
                {
                    Console.WriteLine(C.ColumnName+" "+R[C]);
                }
            }
        }
    }
}
