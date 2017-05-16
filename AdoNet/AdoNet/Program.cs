using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AdoNet
{
    class Program
    {

        static void Main(string[] args)
        {
            TestAdoNet().Wait();

            Console.ReadKey();
        }

        private static async Task TestAdoNet()
        {
            try
            {
                var connectionString = "User ID=Van;Password=606580;Initial Catalog=Table";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlTransaction transaction = connection.BeginTransaction();

                    SqlCommand command = connection.CreateCommand();

                    command.Transaction = transaction;

                    try
                    {
                        command.CommandText = $"SELECT [FirstName] FROM [dbo].[Students] WHERE [Id]={Console.ReadLine()}";

                        SqlDataReader reader = await command.ExecuteReaderAsync();

                        if (reader.HasRows)
                        {
                            await reader.ReadAsync();

                            var when = reader.GetDateTime(0);
                            var firstName = reader.GetString(1);
                            var lastName = reader.GetString(2);

                            Console.WriteLine($"[{when}] {firstName} {lastName}");
                        }

                        reader.Close();

                        command.CommandText =
                            $"INSERT INTO [Students]([FirstName], [LastName]) VALUES('{Console.ReadLine()}', '{Console.ReadLine()}')";

                        var n = await command.ExecuteNonQueryAsync();

                        Console.WriteLine($"Afected rows count: {n}");

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transaction.Rollback();

                            throw ex;
                        }
                        catch (Exception exRollback)
                        {
                            throw exRollback;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
}
