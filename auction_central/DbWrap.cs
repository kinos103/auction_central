using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace auction_central
{
    public class DbWrap
    {
        public DbWrap()
        {
        }

// person object --> DB --> create person obj --> submit attributes 

        public string LoginAuth(string email, string password)
        {
            /*
            string connectionString = @"Database=auction_central;Data Source=us-cdbr-azure-west-b.cleardb.com;User Id=b1a4a9b19daca1;Password=d28c0eba";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(
                    "SELECT COUNT(*) FROM login WHERE type=@type AND emailAddress=@email AND password=@pass",
                    connection))
                {
                    command.Parameters.AddWithValue("@type", type);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pass", password);
                    connection.Open();

                    string result = command.ExecuteScalar().ToString();
                    if (result == "0")
                    {
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


            } */
            return "0";
        }
    }
}