using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigString
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionStringSettings setting = new ConnectionStringSettings
            {
                Name = "MySetting",
                ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Ini;Initial Catalog=ShopDB;Integrated Security=True;"

            };
            Configuration config;
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Add(setting);
            config.Save();
            Console.WriteLine("Saving Completed!!!");
            Console.WriteLine(ConfigurationManager.ConnectionStrings["MySetting"].ConnectionString);
        }
    }
}
