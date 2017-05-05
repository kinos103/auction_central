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
    /// Interaction logic for AuctionDetails.xaml
    /// </summary>
    public partial class AuctionDetails : Page {
	    private Auction auction;

        public AuctionDetails()
        {
            InitializeComponent();
		}

		public AuctionDetails(Auction _auction) {
			InitializeComponent();
			auction = _auction;
			fillFields();
		}

		public void fillFields() {
			lbAuctionId.Text = auction.AuctionId.ToString();
			lbCharity.Text = auction.CharityName;
			lbDate.Text = auction.StartTime.Date.ToLongDateString();
			lbStart.Text= auction.StartTime.ToString("hh:mm tt");
			lbEnd.Text = auction.EndTime.ToString("hh:mm tt");
			lbNpContact.Text = auction.Contact;
			lbPhoneNumber.Text = auction.PhoneNumber;

		}


	}
}
