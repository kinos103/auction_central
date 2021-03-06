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
    /// Interaction logic for BidderHome.xaml
    /// </summary>
    public partial class BidderHome : Page
    {
        public BidderHome()
        {
            InitializeComponent();
        }

        private void currentBids_button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CurrentBids.xaml", UriKind.Relative));
        }

        private void auction_List_button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Auctions.xaml", UriKind.Relative));
        }
    }
}
