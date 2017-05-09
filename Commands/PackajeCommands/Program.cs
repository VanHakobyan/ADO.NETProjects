using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackajeCommands
{
    class Program
    {
        public static void WriteReadeData(DbDataReader reader)
        {
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(reader.GetName(i) + " " + reader[i]);
                    Console.WriteLine(new string('-', 16));
                }
            }

        }
        static void Main(string[] args)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Customers WHERE CustomerNo=1;SELECT * FROM Employees WHERE EmployeeID=1", connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Press any key to see Customer in table");
                Console.ReadKey();
                WriteReadeData(reader);

                Console.WriteLine("Press any key to see Employee in table");
                Console.ReadKey();
                reader.NextResult();
                WriteReadeData(reader);

                reader.Close();
                connection.Close();
                Console.ReadKey();


            }
        }
    }
}
