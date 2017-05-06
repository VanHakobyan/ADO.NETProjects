using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pooling
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder conSB = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                IntegratedSecurity = true,
                InitialCatalog = "ShopDB",
                Pooling = true    //comment
                //Pooling = false //uncomment
            };

            DateTime start = DateTime.Now;
            for (int i = 0; i < 1000; i++)
            {
                SqlConnection connection = new SqlConnection(conSB.ConnectionString);
                connection.Open();
                connection.Close();
            }
            TimeSpan time = DateTime.Now - start;
            Console.WriteLine(time.TotalSeconds);
        }
    }
}
