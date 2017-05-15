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
    public partial class AuctionRequest : Page
    {
        public AuctionRequest()
        {
            InitializeComponent();
        }

       private bool Validate()
        {
            int intPhoneNumber;
            //int intAuctionDate;
            int intNumOfItems;
            bool hasError = false;


            /*if (string.IsNullOrEmpty(charityName.Text))
            {
                MessageBox.Show("Please enter Charity Name");
                hasError = true;
            }

            if(string.IsNullOrEmpty(firstName.Text))
            {
                MessageBox.Show("Please enter your first name");
                hasError = true;
            }

            if(string.IsNullOrEmpty(lastName.Text))
            {
                MessageBox.Show("Please enter your last name");
                hasError = true;
            }*/
            
            if (!int.TryParse(phoneNumber.Text, out intPhoneNumber))
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

            /*if (!int.TryParse(numOfItems.Text, out intNumOfItems))
            {
                MessageBox.Show("Please enter number of items included in the bundle");
                hasError = true;
            }*/





            return hasError;
        }

        //must make sure that request is assigned to nonprofitID

        /*private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var dateString = DatePicker1.SelectedDate.Value.ToShortDateString();

            DatePicker1.SelectedDate = DateTime.Parse(dateString);
             
        }*/

        private void placeRequest_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate())
            {
                MessageBox.Show("One or more fields are wrong");
                return;
            }

            NonProfit npObj = (Window.GetWindow(this) as MainWindow).User as NonProfit;

            string charityName = npObj.OrgName;

            //contactID
//            string firstName = this.firstName.Text;
//            string lastName = this.lastName.Text;

            int phoneNumber = Int32.Parse(this.phoneNumber.Text);
            string location = this.location.Text;

            //dateTimeID
            //should auction date be string? ex: May 10, 2017. See what works best with calendar
            DateTime auctionDate = datePickerAuction.DisplayDate;

            DateTime startTime = this.startTime.SelectedTime.Value;
            DateTime endTime = this.endTime.SelectedTime.Value;

            startTime = new DateTime(auctionDate.Year, auctionDate.Month, auctionDate.Day, startTime.Hour, startTime.Minute,0);

            //check if numOfItems and additionalComments are on auctioninfo table
//            int numOfItems = Int32.Parse(this.numOfItems.Text);
//            string additionalComments = this.additionalComments.Text;


            Auction toCreate = new Auction(-1, charityName, startTime, endTime, npObj.FirstName + " " + npObj.LastName, phoneNumber.ToString(), location);

            new DbWrap().InsertAuction(toCreate, npObj, phoneNumber);
        }

    }
}
