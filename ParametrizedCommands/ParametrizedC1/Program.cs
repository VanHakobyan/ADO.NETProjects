using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametrizedC1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input number:");
            string ID = Console.ReadLine();
            string sqlComm = string.Format($"Select * from customers where CustomerNo={ID}");
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = "(localdb)\\MSSQLLocalDB";
            sb.InitialCatalog = "ShopDB";
            sb.IntegratedSecurity = true;
            using (SqlConnection connection = new SqlConnection(sb.ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlComm, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine($"{reader.GetName(i)} {reader[i]}");
                            Console.WriteLine(new string('_',50));
                        }
                    }
                }

            }
            Console.ReadKey();
        }
    }
}
