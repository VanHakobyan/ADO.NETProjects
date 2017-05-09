using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderWork01
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Customers", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetFieldValue<int>(0));
                Console.WriteLine(reader.GetString(1)+" "+reader.GetString(2)+" "+reader.GetString(3));
                Console.WriteLine(reader.GetFieldValue<string>(7));
                Console.WriteLine("{0:D}",reader.GetDateTime(8));
            }
            reader.Close();
            connection.Close();
        }
    }
}
