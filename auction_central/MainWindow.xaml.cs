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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private NavBar navBar;
        private dBData data;
        public Person User { get; set; }

        public MainWindow() {
            InitializeComponent();
            User = null;
        }

        private void enter_button_Click(object sender, RoutedEventArgs e)
        {

            //data = new dBData();
            //data.AdminData();
            //data.BidderData();
            //data.NonProfitData();
            //data.AuctionData();

            if (User == null)
            {
                HeaderNavBar.Visibility = Visibility.Hidden;
                MainContent.NavigationService.Navigate(new login());
            }
            else
            {
                HeaderNavBar.Visibility = Visibility.Visible;
                switch (User.UserType)
                {
                    case Person.UserTypeEnum.Admin:
                        MainContent.NavigationService.Navigate(new AdminHome());
                        break;
                    case Person.UserTypeEnum.Bidder:
                        MainContent.NavigationService.Navigate(new BidderHome());
                        break;
                    case Person.UserTypeEnum.Nonprofit:
                        MainContent.NavigationService.Navigate(new NPHome());
                        break;
                    default:
                        MainContent.NavigationService.Navigate(new home());
                        break;
                }
            }
            
            enter_button.Visibility = Visibility.Collapsed;
        }
    }
}
