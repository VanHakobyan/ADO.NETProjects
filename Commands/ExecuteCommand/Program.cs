using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder conStr = new SqlConnectionStringBuilder();
            conStr.DataSource = @"(localdb)\MSSQLLocalDB";
            conStr.InitialCatalog = "ShopDB";
            conStr.IntegratedSecurity = true;
            SqlConnection connection = new SqlConnection(conStr.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Phone FROM Customers where CustomerNo=3",connection);
            string phone = (string)cmd.ExecuteScalar();
            Console.WriteLine(phone);      
            connection.Close();
        }
    }
}
