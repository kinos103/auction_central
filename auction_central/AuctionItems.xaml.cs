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
    /// Interaction logic for AuctionItems.xaml
    /// </summary>
    public partial class AuctionItems : Page {
        private List<AuctionItem> items;
        public AuctionItems()
        {
            InitializeComponent();
            AddItems(0);
        }

        public void AddItems(int auctionIdToQuery) {
            //TODO Get list of items from db
            /*items = new List<AuctionItem>();
            for (int i = 0; i < 20; i++) {
                AuctionItem temp = new AuctionItem();
                temp.Name = temp.Name + i;
                items.Add(temp);
            }*/
            items = new DbWrap().AuctionItemsObjList();
            ListBoxAuctionItems.ItemsSource = items;
        }

        private void ListBoxAuctionItems_OnSelected(object sender, RoutedEventArgs e) {
            ListBox sentListBox = sender as ListBox;

            AuctionItem currItem = items[sentListBox.SelectedIndex];
            AuctionID.Text = currItem.AuctionItemId.ToString();
            Condition.Text = Enum.GetName(typeof(AuctionItem.ItemConditionEnum), currItem.ItemCondition);
            StorageLocation.Text = currItem.StorageLocation;
            Size.Text = currItem.Size;
            Donor.Text = currItem.Donor;
            StartingBid.Text = currItem.StartingBid.ToString();
            Quantity.Text = currItem.Quantity.ToString();

            Comments.Text = currItem.Comments;
            ItemName.Text = currItem.Name;
        }
    }
}
