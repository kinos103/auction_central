using System;
using System.Windows;
using System.Windows.Controls;

namespace auction_central
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : Page
    {
        public home()
        {
            InitializeComponent();
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var black = (System.Windows.Media.Brush)converter.ConvertFromString("#000000");
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
            tb.Foreground = black;
        }

        private void header_homeButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("home.xaml", UriKind.Relative));
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        { }

        private void header_searchButton_Click(object sender, RoutedEventArgs e)
        {
            Home.Content = null;
            Home.Content = new home();
        }

        private void header_loginButton_Click(object sender, RoutedEventArgs e)
        {
            Home.Content = new login();

        }

		private void header_auctionsButton_Click(object sender, RoutedEventArgs e) {
			Home.Content = new Auctions();			
		}
	}
}
