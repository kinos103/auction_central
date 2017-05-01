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
    }
}
