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

		private void header_loginButton_Click(object sender, RoutedEventArgs e) {
			(Window.GetWindow(this) as MainWindow).MainContent.NavigationService.Navigate(new login());
		}

		private void header_auctionsButton_Click(object sender, RoutedEventArgs e) {
			(Window.GetWindow(this) as MainWindow).MainContent.NavigationService.Navigate(new Auctions());

		}

		private void header_homeButton_Click(object sender, RoutedEventArgs e) {
			(Window.GetWindow(this) as MainWindow).MainContent.NavigationService.Navigate(new home());
		}
	}
}
