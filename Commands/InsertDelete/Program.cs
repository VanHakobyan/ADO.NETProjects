using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertDelete
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
            //Instert
            SqlCommand insertCommand = connection.CreateCommand();
            insertCommand.CommandText = "Insert Customers Values ('Van','Hakobyan','Meliqi','Babajanyan 15',NULL,'Aparan','(093)579717',NULL)";
            int rowA = insertCommand.ExecuteNonQuery();
            Console.WriteLine("Delete Row"+rowA);
            //Delete
            SqlCommand deleteCommand = connection.CreateCommand();
            deleteCommand.CommandText = "Delete Customers where FName = 'Van'";
            int rowB = deleteCommand.ExecuteNonQuery();
            Console.WriteLine("Delete Row"+rowA);
            connection.Close();
        }
    }
}
