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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUpLoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            (Window.GetWindow(this) as MainWindow).MainContent.NavigationService.Navigate(new login());
        }

        private void SignUpButton_OnClick(object sender, RoutedEventArgs e)
        {
            var userType = (ComboBoxItem)ComboBox.SelectedItem;

            if (Equals(userType, Admin))
            {
                signUp(Person.UserTypeEnum.Admin);

            }
            else if (Equals(userType, NP))
            {
                signUp(Person.UserTypeEnum.Nonprofit);
            }
            else if (Equals(userType, Bidder))
            {
                signUp(Person.UserTypeEnum.Bidder);
            }
            else
            {
                MessageBox.Show("Please Select a User Type");
            }
        }

        private void signUp(Person.UserTypeEnum type)
        {
            MessageBox.Show("USER TYPE WORKS");
        }
    }
}
