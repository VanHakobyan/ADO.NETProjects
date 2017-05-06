using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginWPFStringBilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            SqlConnectionStringBuilder connectionSB = new SqlConnectionStringBuilder();

            connectionSB.DataSource = @"(localdb)\MSSQLLocalDB";
            connectionSB.InitialCatalog = "ShopDB";
            connectionSB.UserID = LoginT.Text;
            connectionSB.Password = PasswordT.Text;

            using (SqlConnection connection= new SqlConnection(connectionSB.ConnectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection " + connection.State + " to " + connection.Database);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
