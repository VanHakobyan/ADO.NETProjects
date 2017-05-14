using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryKey
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            DataColumn col1 = table.Columns.Add("first");
            DataColumn col2 = table.Columns.Add("second");

            table.Constraints.Add(new UniqueConstraint(col1, true));
            Console.WriteLine(table.Columns[0].Unique);
            Console.WriteLine(table.PrimaryKey.Length);
            Console.WriteLine(table.PrimaryKey[0].ColumnName);
        }
    }
}
