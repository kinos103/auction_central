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

namespace auction_central {
	/// <summary>
	/// Interaction logic for NavBar.xaml
	/// </summary>
	public partial class NavBar:UserControl {
		public NavBar() {
			InitializeComponent();
		}

		private void searchBox_TextChanged(object sender, TextChangedEventArgs e) {

		}

		private void TextBox_GotFocus(object sender, RoutedEventArgs e) {

		}

		private void header_searchButton_Click(object sender, RoutedEventArgs e) {

		}

		private void header_auctionsButton_Click(object sender, RoutedEventArgs e) {
			(Window.GetWindow(this) as MainWindow).MainContent.NavigationService.Navigate(new Auctions());

		}

		private void header_homeButton_Click(object sender, RoutedEventArgs e) {

		    switch ((Window.GetWindow(this) as MainWindow).User.UserType)
		    {
                case Person.UserTypeEnum.Admin:
                    (Window.GetWindow(this) as MainWindow).MainContent.NavigationService.Navigate(new AdminHome());
		            (Window.GetWindow(this) as MainWindow).MainContent.NavigationUIVisibility = NavigationUIVisibility.Visible;
                    break;
		        case Person.UserTypeEnum.Nonprofit:
                    (Window.GetWindow(this) as MainWindow).MainContent.NavigationService.Navigate(new NPHome());
		            (Window.GetWindow(this) as MainWindow).MainContent.NavigationUIVisibility = NavigationUIVisibility.Visible;
                    break;
                case Person.UserTypeEnum.Bidder:
                    (Window.GetWindow(this) as MainWindow).MainContent.NavigationService.Navigate(new BidderHome());
		            (Window.GetWindow(this) as MainWindow).MainContent.NavigationUIVisibility = NavigationUIVisibility.Visible;
                    break;
		        default:
		            (Window.GetWindow(this) as MainWindow).MainContent.NavigationUIVisibility = NavigationUIVisibility.Hidden;
                    (Window.GetWindow(this) as MainWindow).HeaderNavBar.Visibility = Visibility.Hidden;
                    (Window.GetWindow(this) as MainWindow).MainContent.NavigationService.Navigate(new login());
		            break;
		    }
		}

	    private void header_signOutButton_Click(object sender, RoutedEventArgs e)
	    {
	        

	        var confirmResult = MessageBox.Show("Are you sure you want to sign out?",
	            "Sign Out",
	            MessageBoxButton.YesNo);
	        if (confirmResult == MessageBoxResult.Yes)
	        {
	            (Window.GetWindow(this) as MainWindow).User = null;
	            (Window.GetWindow(this) as MainWindow).MainContent.NavigationUIVisibility = NavigationUIVisibility.Hidden;
	            (Window.GetWindow(this) as MainWindow).HeaderNavBar.Visibility = Visibility.Hidden;
	            (Window.GetWindow(this) as MainWindow).MainContent.NavigationService.Navigate(new login());
            }
	        else
	        {
	            // do nothing, don't want to sign out
	        }

        }

        private void header_donorButton_Click(object sender, RoutedEventArgs e)
        {
            (Window.GetWindow(this) as MainWindow).MainContent.NavigationService.Navigate(new Donor());
        }
    }
}
