using System.Data.SqlClient;
using System.Windows;

namespace ExecuteAsync
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
        string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;";

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection= new SqlConnection(conString))
            {
                connection.Open();
                using (SqlCommand cmd= new SqlCommand("WAITFOR DELAY '00:00:07'",connection))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Execute non async");
                }
            }
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
              await  connection.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("WAITFOR DELAY '00:00:07'", connection))
                {
                    await cmd.ExecuteNonQueryAsync();
                    MessageBox.Show("Execute async");
                }
            }
        }
    }
}
