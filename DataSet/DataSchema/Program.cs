using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSchema
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\ADO.NET\DATA\ShopDB.mdf; Integrated Security = True; Connect Timeout = 30");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from customers", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable schema = reader.GetSchemaTable();
            foreach (DataRow row in schema.Rows)
            {
                foreach (DataColumn col in schema.Columns)
                {
                    Console.WriteLine($"{col.ColumnName} {row[col]}");
                    Console.WriteLine();
                }
            }

          //  DataTable customers = new DataTable("customers");

        }
    }
}
