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
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class AuctionRequest : Page {
        private List<Auction> allAuctions;
        private List<Auction> upComing;
        private List<Auction> belongsToNP;
        private NonProfit npObj;

        public AuctionRequest()
        {
            InitializeComponent();
            allAuctions = new DbWrap().AuctionObjList();
            upComing = new List<Auction>();
            belongsToNP = new List<Auction>();

            this.Loaded += (sender, args) => {
                npObj = (Window.GetWindow(this) as MainWindow).User as NonProfit;
                AddUpcoming();
                AddBelongsTo();
            };



            }

        private void AddBelongsTo() {
            foreach (Auction auction in upComing) {
                if (auction.CharityName == npObj.OrgName) {
                    belongsToNP.Add(auction);
                }
            }
        }

        private void AddUpcoming() {
            foreach (Auction auction in allAuctions) {
                if (auction.EventDate >= DateTime.Now) {
                    upComing.Add(auction);
                }
            }
        }

        // false if no error, true if error
        private bool ValidateDates() {
            bool hasError = false;

            // no more than 25 into future
            if (upComing.Count >= 25) {
                MessageBox.Show("Maximum number of auctions reached for current time frame");
                hasError = true;
            }
            // no more than 3 months away
            if (datePickerAuction.SelectedDate.Value > DateTime.Now.AddMonths(3)) {
                MessageBox.Show("Auction too far in advance. Three months adhead is farthest");
                hasError = true;
            }
            // no more than 1 per year? Changed to no more than one up coming
            if (belongsToNP.Count > 3) {
                MessageBox.Show("Auction for non-profit already scheduled");
                hasError = true;
            }

            return hasError;
        }

        // false if no error, true if error
       private bool Validate()
        {
            long intPhoneNumber;
            bool hasError = false;


            
            if (!Int64.TryParse(phoneNumber.Text, out intPhoneNumber))
            {
                MessageBox.Show("Please enter phone number");
                hasError = true;
            }

            if(string.IsNullOrEmpty(location.Text))
            {
                MessageBox.Show("Please enter location");
                hasError = true;
            }

            if (string.IsNullOrEmpty(startTime.Text))
            {
                MessageBox.Show("Please enter start time for the event");
                hasError = true;
            }

            if (string.IsNullOrEmpty(endTime.Text))
            {
                MessageBox.Show("Please enter end time for the event");
                hasError = true;
            }

            // if it's empty don't ValidateDates, if it has text we can ValidateDates
            if (string.IsNullOrEmpty(datePickerAuction.Text)) {
                hasError = true;
            }
            else if (ValidateDates()) {
                hasError = true;
            }
            return hasError;
        }

        //must make sure that request is assigned to nonprofitID


        private void placeRequest_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                MessageBox.Show("One or more fields are wrong");
                return;
            }


            string charityName = npObj.OrgName;

            //contactID

            long phoneNumber = Int64.Parse(this.phoneNumber.Text);
            string location = this.location.Text;

            //dateTimeID
            //should auction date be string? ex: May 10, 2017. See what works best with calendar
            DateTime auctionDate = datePickerAuction.DisplayDate;

            DateTime startTime = this.startTime.SelectedTime.Value;
            DateTime endTime = this.endTime.SelectedTime.Value;

            startTime = new DateTime(auctionDate.Year, auctionDate.Month, auctionDate.Day, startTime.Hour, startTime.Minute,0);

            //check if numOfItems and additionalComments are on auctioninfo table

            Auction toCreate = new Auction(-1, charityName, startTime, endTime, npObj.FirstName + " " + npObj.LastName, phoneNumber.ToString(), location);

            new DbWrap().InsertAuction(toCreate, npObj, phoneNumber);
        }

    }
}
