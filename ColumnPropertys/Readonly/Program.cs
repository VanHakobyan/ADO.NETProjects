using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readonly
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\ADO.NET\DATA\ShopDB.mdf;Integrated Security=True;Connect Timeout=30");
            DataTable table = new DataTable("Custom");
            DataColumn column = new DataColumn("readonly", typeof(int));
            //column.ReadOnly = true;
            column.ReadOnly = false;
            column.AllowDBNull = true;
            table.Columns.Add(column);
            DataRow row = table.NewRow();
            //row["readonly"] = 52;
            row[0] =DBNull.Value;

            table.Rows.Add(row);
            //foreach (DataRow rows in table.Rows)
            //{
            //    foreach (DataColumn col in table.Columns)
            //    {
            //        Console.WriteLine($"{col.DataType} {rows[col]} {col.ReadOnly}");
            //    }
            //}

            Console.WriteLine(table.Rows[0][0]);
        }
    }
}
