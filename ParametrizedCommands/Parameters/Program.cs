using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = "(localdb)\\MSSQLLocalDB";
            sb.InitialCatalog = "ShopDB";
            sb.IntegratedSecurity = true;
            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            SqlCommand cmd = new SqlCommand("SET @Parameter=2;", connection);
            SqlParameter param = cmd.Parameters.Add("Parameter", System.Data.SqlDbType.Int);
            param.Direction = System.Data.ParameterDirection.Output;
            connection.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Value:"+param.Value);
            Console.ReadKey();
            connection.Close();


        }
    }
}
