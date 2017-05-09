using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteTable
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
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(reader.GetName(i)+": "+reader[i]);
                }
                Console.WriteLine(new string('-',20));
            }
            reader.Close();
            connection.Close();
            Console.ReadKey();

        }
    }
}
