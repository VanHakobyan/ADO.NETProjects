using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableWork
{
    class Program
    {
        public static DataTable Schema(SqlDataReader reader,string tableName)
        {
            DataTable table = new DataTable(tableName);
            for (int i = 0; i < reader.FieldCount; i++)
            {
                table.Columns.Add(new DataColumn(reader.GetName(i), reader.GetFieldType(i)));
            }
            return table;
        }
        public static void write(DataTable table,SqlDataReader reader)
        {
            while (reader.Read())
            {
                DataRow row = table.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[i] = reader[i];
                }
                table.Rows.Add(row);

            }
        }
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder sqlsb = new SqlConnectionStringBuilder();
            sqlsb.DataSource = "(localdb)\\MSSSQLLOcaldb";
            sqlsb.IntegratedSecurity = true;
            sqlsb.InitialCatalog = "shopdb";
            SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\ADO.NET\DATA\ShopDB.mdf; Integrated Security = True; Connect Timeout = 30");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from customers", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = Schema(reader, "customers");
            foreach (DataColumn item in table.Columns)
            {
                Console.WriteLine($"{item.ColumnName}  {item.DataType}");
            }
            write(table, reader);
            Console.WriteLine(new string('-',57));
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    Console.WriteLine($"{col.ColumnName} {row[col]}");
                 
                }
                Console.WriteLine();
            }
            connection.Close();
            reader.Close();
        }
    }
}
