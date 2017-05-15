﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private DbWrap dbWrap;
        public SignUp()
        {
            InitializeComponent();
            dbWrap = new DbWrap();
            OrgNames.ItemsSource = dbWrap.ReturnOrgNames();
        }

        private void SignUpLoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            (Window.GetWindow(this) as MainWindow).MainContent.NavigationService.Navigate(new login());
        }

        

        private void SignUpButton_OnClick(object sender, RoutedEventArgs e)
        {
            var userType = (ComboBoxItem)ComboBox.SelectedItem;
            signUp(userType);
        }

        private void signUp(ComboBoxItem item)
        {
            String firstName = SignUpFirstName.Text;
            String lastName = SignUpLastName.Text;
            String email = SignUpEmail.Text;
            Int64 phone = Int64.Parse(SignUpPhone.Text);
            String password = SignUpPassword.Password;
            String passwordConfirm = SignUpPasswordConfirm.Password;
            var navigationService = this.NavigationService;


            if (firstName == "" || lastName == "")
            {
                MessageBox.Show("Error creating account: Check name");
                return;
            }

            if (!IsValidEmailAddress(email))
            {
                MessageBox.Show("Error creating account: Check email");
                return;
            }

            if (!IsValidPassword(password, passwordConfirm))
            {
                MessageBox.Show("Error creating account: Check password");
                return;
            }

            if (Equals(item, Admin))
            {
                dbWrap.InsertAdmin(firstName, lastName, email, password, phone, Person.UserTypeEnum.Admin);

                Person returned = dbWrap.LoginExists(email, password, Person.UserTypeEnum.Admin);
                if (returned == null)
                {
                    MessageBox.Show("Error");
                    return;
                }
                // everything should happen in the MainWindow so this should be safe
                (Window.GetWindow(this) as MainWindow).User = returned;
                navigationService?.Navigate(new Uri("AdminHome.xaml", UriKind.Relative));
                (Window.GetWindow(this) as MainWindow).HeaderNavBar.Visibility = Visibility.Visible;
                (Window.GetWindow(this) as MainWindow).MainContent.NavigationUIVisibility = NavigationUIVisibility.Visible;   
            }
            else if (Equals(item, NP))
            {
                if (OrgNames.SelectionBoxItem.ToString() == "")
                {
                    MessageBox.Show("Please select an Org");
                    return;
                }

                dbWrap.InsertNonprofit(firstName, lastName, email, password, phone, Person.UserTypeEnum.Nonprofit, OrgNames.SelectionBoxItem.ToString());

                Person returned = dbWrap.LoginExists(email, password, Person.UserTypeEnum.Nonprofit);
                if (returned == null)
                {
                    MessageBox.Show("Error");
                    return;
                }
                // everything should happen in the MainWindow so this should be safe
                (Window.GetWindow(this) as MainWindow).User = returned;
                navigationService?.Navigate(new Uri("NPHome.xaml", UriKind.Relative));
                (Window.GetWindow(this) as MainWindow).HeaderNavBar.Visibility = Visibility.Visible;
                (Window.GetWindow(this) as MainWindow).MainContent.NavigationUIVisibility = NavigationUIVisibility.Visible;
            }
            else if (Equals(item, Bidder))
            {
                Address address = new Address("number", "city", "state", 92610);
                CreditCard creditCard = new CreditCard("number", 123, "name", "expdate");
                auction_central.Bidder bidder = new Bidder(Person.UserTypeEnum.Bidder, 0, firstName, lastName, email, "card", "address", phone.ToString());

                dbWrap.InsertBidder(bidder, Person.UserTypeEnum.Bidder, password, creditCard, address);

                Person returned = dbWrap.LoginExists(email, password, Person.UserTypeEnum.Bidder);
                if (returned == null)
                {
                    MessageBox.Show("Error");
                    return;
                }
                // everything should happen in the MainWindow so this should be safe
                (Window.GetWindow(this) as MainWindow).User = returned;
                navigationService?.Navigate(new Uri("BidderHome.xaml", UriKind.Relative));
                (Window.GetWindow(this) as MainWindow).HeaderNavBar.Visibility = Visibility.Visible;
                (Window.GetWindow(this) as MainWindow).MainContent.NavigationUIVisibility = NavigationUIVisibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Select a User Type");
            }
            
        }

        public static bool IsValidEmailAddress(string emailaddress)
        {
            try
            {
                Regex rx = new Regex(
                    @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
                return rx.IsMatch(emailaddress);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool IsValidPassword(string password, string passwordConfirm)
        {
            if (password.Length >= 8)
            {
                if (password == passwordConfirm)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void ComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrgNames.Visibility = Equals((ComboBoxItem)ComboBox.SelectedItem, NP) ? Visibility.Visible : Visibility.Collapsed;
            SignUpCreditCard.Visibility = Equals((ComboBoxItem)ComboBox.SelectedItem, Bidder) ? Visibility.Visible : Visibility.Collapsed;
            SignUpCVV.Visibility = Equals((ComboBoxItem)ComboBox.SelectedItem, Bidder) ? Visibility.Visible : Visibility.Collapsed;
            SignUpAddress.Visibility = Equals((ComboBoxItem)ComboBox.SelectedItem, Bidder) ? Visibility.Visible : Visibility.Collapsed;
            SignUpCity.Visibility = Equals((ComboBoxItem)ComboBox.SelectedItem, Bidder) ? Visibility.Visible : Visibility.Collapsed;
            SignUpCreditCardExpDate.Visibility = Equals((ComboBoxItem)ComboBox.SelectedItem, Bidder) ? Visibility.Visible : Visibility.Collapsed;
            SignUpState.Visibility = Equals((ComboBoxItem)ComboBox.SelectedItem, Bidder) ? Visibility.Visible : Visibility.Collapsed;
            SignUpZipcode.Visibility = Equals((ComboBoxItem)ComboBox.SelectedItem, Bidder) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
