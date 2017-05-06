using System;
using System.Configuration;
namespace ProtectedANDUnprotected
{
    class Program
    {
        static void Main(string[] args)
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("COnnectionStr1", "SomeConnectionString"));
            config.Save();

            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
            if (section.SectionInformation.IsProtected)
            {
                section.SectionInformation.UnprotectSection();
            }
            else
            {
                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            }
            config.Save();
            Console.WriteLine($"Protected: {section.SectionInformation.IsProtected}");
            Console.WriteLine();
        }
    }
}
