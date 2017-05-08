using System;
using System.Collections.Generic;
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
                var navigationService = this.NavigationService;
                navigationService?.Navigate(new Uri("AdminHome.xaml", UriKind.Relative));
            }

            else if (Equals(user, NP))
            {
                var navigationService = this.NavigationService;
                navigationService?.Navigate(new Uri("NPHome.xaml", UriKind.Relative));
            }
            else if (Equals(user, Bidder))
            {
                var navigationService = this.NavigationService;
                navigationService?.Navigate(new Uri("BidderHome.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("You Stink :(");

            }
        }




            /* this.Login.Navigate(typeof(NPHome), null);
             this.Login.Navigate(typeof(NPHome), null);*/
            /* if (comboBox_Loaded "Admin")
             {

             }
             
            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            if (== "Admin")
            {
                this.NavigationService.Navigate(new Uri("AdminHome.xaml", UriKind.Relative));
            }

            else if (value == "Bidder")
            {
                this.NavigationService.Navigate(new Uri("BidderHome.xaml", UriKind.Relative));
            }

            else if (value == "Non-Profit")
            {*/

        private void comboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            /*
            if (comboBox.SelectedIndex == 0)
            {
                comboBox.Items.Add("Admin");
                comboBox.Items.Add("Bidder");
                comboBox.Items.Add("Non-Profit");
                
            }
            */

            /* 
             * Connection string: 
             * Database=auction_central;Data Source=us-cdbr-azure-west-b.cleardb.com;User Id=b1a4a9b19daca1;Password=d28c0eba
             * 
             * 
             * MySqlConnection connection;
               string connectionString = "Database=auction_central;Data Source=us-cdbr-azure-west-b.cleardb.com;User Id=b1a4a9b19daca1;Password=d28c0eba";
               connection = new MySqlConnection(connectionString);
               try
               {
                   connection.Open();
               }
           */  
        }
        

        private void comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            /*List<string> data = new List<string>();

            Admin = data.Add("Admin");
            data.Add("Bidder");
            data.Add("Non-Profit");

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            /*... Make the first item selected.
            comboBox.SelectedIndex = 0;

            */
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /* // ... Get the ComboBox.
             var comboBox = sender as ComboBox;

             // ... Set SelectedItem as Window Title.
             string value = comboBox.SelectedItem as string;
             this.Title = "Selected: " + value;
          */
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
 

