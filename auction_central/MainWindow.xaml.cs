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
        public Person User { get; set; }

        public MainWindow() {
            InitializeComponent();
            User = null;
        }

        private void enter_button_Click(object sender, RoutedEventArgs e)
        {
            HeaderNavBar.Visibility = Visibility.Visible;
            MainContent.NavigationService.Navigate(new home());
//            MainContent.NavigationService.Navigate(new Calendar());
            enter_button.Visibility = Visibility.Collapsed;
        }
    }
}
