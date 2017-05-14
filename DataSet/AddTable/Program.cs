using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\ADO.NET\DATA\ShopDB.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            DataTable table = new DataTable("Van");
            DataColumn column1 = new DataColumn("first", typeof(int));
            DataColumn column2 = new DataColumn("second");
            column1. = true;
            table.Columns.Add(column1);
            table.Columns.Add(column2);
            DataRow row = table.NewRow();
            row[0] = 1;
            row[1] = "van";
            table.Rows.Add(row);
            foreach (DataRow rows in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    Console.WriteLine($"{col.ColumnName} {row[col]}");
                }
            }
        }
    }
}
