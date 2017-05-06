using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionUsing
{
    class Program
    {
        static void stateChanger(object sender, StateChangeEventArgs e)
        {
            SqlConnection conn = sender as SqlConnection;
            Console.WriteLine(new string('-', 50));
            Console.WriteLine
                (
                "Connection To " + Environment.NewLine +
                "Data Source " + conn.DataSource + Environment.NewLine +
                "DataBase " + conn.Database + Environment.NewLine +
                "State " + conn.State
                );

        }
        static void Main(string[] args)
        {
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;DataBase=ShopDB;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.StateChange += stateChanger;
                try
                {
                    connection.Open();
                    // Console.WriteLine(connection.State);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
