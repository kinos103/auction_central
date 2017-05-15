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
	/// Interaction logic for Auctions.xaml
	/// </summary>
	public partial class Auctions:Page {
		private List<Auction> auctions;
		public Auctions() {
			InitializeComponent();
			loadAuctions();
		}

		public void loadAuctions() {
			auctions = new DbWrap().AuctionObjList();
			// Test data if db is being wonky
			/*
			auctions = new List<Auction>();
			for (int i = 0; i < 7; ++i)
			{
				Auction tempAuction = new Auction();
				tempAuction.CharityName += i.ToString();
				auctions.Add(tempAuction);
			}*/
			listBoxAuctions.ItemsSource = auctions;
		}

		// method for when they click in the list box
		private void OnMouseUp(object sender, MouseButtonEventArgs e) {
			int index = this.listBoxAuctions.SelectedIndex;
			DetailFrame.NavigationService.Navigate(new AuctionDetails(auctions[index]));
		}
	}
}
