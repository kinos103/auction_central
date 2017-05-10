﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;

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
                login_now(Person.UserTypeEnum.Admin);
                
            }
            else if (Equals(user, NP))
            {
                login_now(Person.UserTypeEnum.Nonprofit);
            }
            else if (Equals(user, Bidder))
            {
                login_now(Person.UserTypeEnum.Bidder);
            }
            else
            {
                MessageBox.Show("Please Select a User Type");

            }
        }

        //TODO check connection string, error
        private void login_now(Person.UserTypeEnum type)
        {
            string email = LoginEmail.Text.Normalize().Trim();
            string password = LoginPassword.Password.Normalize().Trim();
            var navigationService = this.NavigationService;

            DbWrap dbWrap = new DbWrap();
            Person returned = dbWrap.LoginExists(email, password, type);
            if (returned == null)
            {
                MessageBox.Show("Error Logging In");
                return;
            }
            // everything should happen in the MainWindow so this should be safe
            (Window.GetWindow(this) as MainWindow).User = returned;

            switch (type)
            {
                case Person.UserTypeEnum.Admin:
                    navigationService?.Navigate(new Uri("AdminHome.xaml", UriKind.Relative));
                    break;
                case Person.UserTypeEnum.Bidder:
                    navigationService?.Navigate(new Uri("BidderHome.xaml", UriKind.Relative));
                    break;
                case Person.UserTypeEnum.Nonprofit:
                    navigationService?.Navigate(new Uri("NPHome.xaml", UriKind.Relative));
                    break;
            }
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
 

