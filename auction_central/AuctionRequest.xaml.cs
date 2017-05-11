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

        //must make sure that request is assigned to nonprofitID

        private void placeRequest_Click(object sender, RoutedEventArgs e)
        {
            string charityName = this.charityName.Text;

            //contactID
            string firstName = this.firstName.Text;
            string lastName = this.lastName.Text;

            int phoneNumber = Int32.Parse(this.phoneNumber.Text);
            string location = this.location.Text;

            //dateTimeID
            //should auction date be string? ex: May 10, 2017. See what works best with calendar
            int auctionDate = Int32.Parse(this.auctionDate.Text);
            string startTime = this.startTime.Text;
            string endTime = this.endTime.Text;

            //check if numOfItems and additionalComments are on auctioninfo table
            int numOfItems = Int32.Parse(this.numOfItems.Text);
            string additionalComments = this.additionalComments.Text;


        }
    }
}
