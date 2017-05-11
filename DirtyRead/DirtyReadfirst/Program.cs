using System;
using System.Data.SqlClient;

namespace DirtyReadfirst
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=(Localdb)\MSSQLLocalDB; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

            SqlConnection connection = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand("UPDATE Customers SET Phone = 'TEST' WHERE CustomerNo = 1", connection);
            //cmd = new SqlCommand("UPDATE Customers SET Phone = '(052)1245789' WHERE CustomerNo = 1", connection);

            Console.WriteLine("Step 1. Press any key to execute command...");
            Console.ReadKey();

            connection.Open();

            cmd.Transaction = connection.BeginTransaction();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Step 3. Press any key to rollback transaction...");
            Console.ReadKey();

            cmd.Transaction.Rollback();
            connection.Close();

            Console.WriteLine("Transaction rollback");


        }
    }
}
