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
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;

namespace auction_central
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {


        public login()
        {
            InitializeComponent();
        }

        private void login_loginButton_Click(object sender, RoutedEventArgs e)
        {
            var user = (ComboBoxItem)ComboBox.SelectedItem;
            
            if (Equals(user, Admin))
            {
                login_now("admin");
                
            }
            else if (Equals(user, NP))
            {
                login_now("non-profit");
            }
            else if (Equals(user, Bidder))
            {
                login_now("bidder");
            }
            else
            {
                MessageBox.Show("Please Select a User Type");

            }
        }


        //This should work but haven't been able to test
        //TODO check connection string, error
        private void login_now(string type)
        {
            string email = LoginEmail.Text.Normalize().Trim();
            string password = LoginPassword.Text.Normalize().Trim();
            var navigationService = this.NavigationService;
            string connectionString = @"Database=auction_central;Data Source=us-cdbr-azure-west-b.cleardb.com;User Id=b1a4a9b19daca1;Password=d28c0eba";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(
                    "SELECT COUNT(*) FROM login WHERE type=@type AND emailAddress=@email AND password=@pass", connection)) {
                    command.Parameters.AddWithValue("@type", type);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pass", password);

                    connection.Open();
                    string result = command.ExecuteScalar().ToString();
                    if (result == "0") {
                        MessageBox.Show("Error Logging In");
                    }
                    else if (type.Equals("admin"))
                    {
                        navigationService?.Navigate(new Uri("AdminHome.xaml", UriKind.Relative));
                    }
                    else if (type.Equals("non-profit"))
                    {
                        navigationService?.Navigate(new Uri("NPHome.xaml", UriKind.Relative));
                    }
                    else if (type.Equals("bidder"))
                    {
                        navigationService?.Navigate(new Uri("BidderHome.xaml", UriKind.Relative));
                    }
                }
            }
        }

        //click textbox and remvoe text before typing

        public void TextBox_Focus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_Focus;
        }
    }
}
 

