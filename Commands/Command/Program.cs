using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
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
            //First method----------------------
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select * from ShopDB";
            connection.Close();
        }
    }
}
