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
    /// Interaction logic for Page5.xaml
    /// </summary>
    public partial class NPEventDetails : Page
    {

        private List<Auction> allAuctions;
        private List<Auction> upComing;
        private List<Auction> belongsToNP;
        private NonProfit npObj;
        public NPEventDetails()
        {
            InitializeComponent();
            allAuctions = new DbWrap().AuctionObjList();
            upComing = new List<Auction>();
            belongsToNP = new List<Auction>();

            this.Loaded += (sender, args) => {
                npObj = (Window.GetWindow(this) as MainWindow).User as NonProfit;
                AddUpcoming();
                AddBelongsTo();

                if (belongsToNP.Count != 0)
                {
                    AuctionID.Text += ": " + belongsToNP[0].CharityName + "-" + belongsToNP[0].EventDate.ToString("M") + "-" + belongsToNP[0].EventDate.Year;
                    AuctionDate.Text += ": " + belongsToNP[0].EventDate.ToShortDateString();
                    CharityName.Text += ": " + belongsToNP[0].CharityName;
                    StartTime.Text += ": " + belongsToNP[0].StartTime.ToShortTimeString();
                    EndTime.Text += ": " + belongsToNP[0].EndTime.ToShortTimeString();
                    Location.Text += ": " + belongsToNP[0].Location;
                }

                NoAuction.Visibility = belongsToNP.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
                AuctionID.Visibility = belongsToNP.Count != 0 ? Visibility.Visible : Visibility.Collapsed;
                AuctionDate.Visibility = belongsToNP.Count != 0 ? Visibility.Visible : Visibility.Collapsed;
                CharityName.Visibility = belongsToNP.Count != 0 ? Visibility.Visible : Visibility.Collapsed;
                StartTime.Visibility = belongsToNP.Count != 0 ? Visibility.Visible : Visibility.Collapsed;
                Location.Visibility = belongsToNP.Count != 0 ? Visibility.Visible : Visibility.Collapsed;
                EndTime.Visibility = belongsToNP.Count != 0 ? Visibility.Visible : Visibility.Collapsed;
                addItemsButton.Visibility = belongsToNP.Count != 0 ? Visibility.Visible : Visibility.Collapsed;
                ViewItemsButton.Visibility = belongsToNP.Count != 0 ? Visibility.Visible : Visibility.Collapsed;
                AddAuctionButton.Visibility = belongsToNP.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
            };
        }

        private void AddBelongsTo()
        {
            foreach (Auction auction in upComing)
            {
                if (auction.CharityName == npObj.OrgName)
                {
                    belongsToNP.Add(auction);
                }
            }
        }

        private void AddUpcoming()
        {
            foreach (Auction auction in allAuctions)
            {
                if (auction.EventDate >= DateTime.Now)
                {
                    upComing.Add(auction);
                }
            }
        }

        private void addItemsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddItem(this.belongsToNP.First()));
        }

        private void ViewItemsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AuctionItems(belongsToNP.First()));
        }

        private void AddAuctionButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AuctionRequest.xaml", UriKind.Relative));
        }
    }
}
