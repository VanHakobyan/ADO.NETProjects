using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionString
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB; Integrated Security=True";
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                connection.Open();
                Console.WriteLine("connection opened");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("connection closed");
            }
        }
    }
}
