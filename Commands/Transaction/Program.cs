using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder str = new SqlConnectionStringBuilder();
            str.DataSource = "(localdb)\\MSSQLLocalDB";
            str.InitialCatalog = "ShopDB";
            str.IntegratedSecurity = true;

            SqlConnection connection = new SqlConnection(str.ConnectionString);
           
            string smdText = "Update Customers set phone = '16541657498' where CustomerNo=1";
            SqlCommand cmd = new SqlCommand(smdText, connection);
           // cmd = new SqlCommand("Update Customers set phone = '16541657498' where CustomerNo=1");
            try
            {
                connection.Open();
                cmd.Transaction = connection.BeginTransaction();
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
                Console.WriteLine("Transaction Commited");
            }
            catch (Exception e)
            {
                cmd.Transaction.Rollback();
                Console.WriteLine("Transaction Rollback");
            }
        }
    }
}
