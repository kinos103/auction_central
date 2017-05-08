﻿using System;
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
    /// Interaction logic for NPHome.xaml
    /// </summary>
    public partial class NPHome : Page
    {
        public NPHome()
        {
            InitializeComponent();
        }

        private void eventDetails_button_Click(object sender, RoutedEventArgs e)
        {
            /*npHome.Content = new NPEventDetails();*/
            this.NavigationService.Navigate(new Uri("NPEventDetails.xaml", UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AuctionRequest.xaml", UriKind.Relative));
        }
    }
}
