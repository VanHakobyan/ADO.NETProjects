using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DataColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable newTable = new DataTable("First");
            DataColumn first = new DataColumn("name", typeof(string));
            DataColumn second = new DataColumn("age", typeof(int));
            DataColumnCollection coll = newTable.Columns;
            coll.AddRange(new DataColumn[] { first, second });
            foreach (DataColumn item in newTable.Columns)
            {
                Console.WriteLine(item.ColumnName+" "+item.DataType);
                Console.WriteLine(new string('-',40));
            }

        }
    }
}
