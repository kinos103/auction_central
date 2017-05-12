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
using MaterialDesignThemes.Wpf;

namespace auction_central
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    /// 

    public partial class Calendar : Page {

        private Dictionary<DateTime, List<Auction>> auctions;

        public Calendar() {
            InitializeComponent();
            SetCalendarDates();

            auctions = new Dictionary<DateTime, List<Auction>>();

            DbWrap dbWrap = new DbWrap();

            // temp data for testing if db is being wonky
            /*List<Auction> tempAuctionList = new List<Auction>();
            for (int i = 0; i < 5; ++i) {
                Auction temp = new Auction();
	            temp.StartTime = DateTime.Now.AddDays(i + 1);
                tempAuctionList.Add(temp);
            }
            Auction temp2 = new Auction();
            temp2.StartTime = DateTime.Now.AddDays(1);
            tempAuctionList.Add(temp2);
            temp2 = new Auction();
            temp2.StartTime = DateTime.Now.AddMonths(1);
            tempAuctionList.Add(temp2);*/



            // Get list of all auctions from the database
            List<Auction> tempAuctionList = dbWrap.AuctionObjList();



            // Take the list from database and convert it to a dictionary
            // keys are dateTimes for a day
            // values are a list of auction for that day
            auctions = ConvertListToDict(tempAuctionList);


            // Add all the auctions returned from the db to all the calendars
            AddAuctionsToCalendars(CalendarSingleMonth, CalendarThreeMonthFirst, CalendarThreeMonthSecond, CalendarThreeMonthThird);


            // Add event handlers to all the calendars
            CalendarSingleMonth.SelectedDatesChanged += OnSelectedDatesChanged;
            CalendarThreeMonthFirst.SelectedDatesChanged += OnSelectedDatesChanged;
            CalendarThreeMonthSecond.SelectedDatesChanged += OnSelectedDatesChanged;
            CalendarThreeMonthThird.SelectedDatesChanged += OnSelectedDatesChanged;

            CalendarSingleMonth.DisplayDateChanged += OnDisplayDateChanged;
            CalendarThreeMonthFirst.DisplayDateChanged += OnDisplayDateChanged;
            CalendarThreeMonthSecond.DisplayDateChanged += OnDisplayDateChanged;
            CalendarThreeMonthThird.DisplayDateChanged += OnDisplayDateChanged;


        }

        private void AddAuctionsToCalendars(params System.Windows.Controls.Calendar[] calendarsToUpdate) {
            // go through each calendar passed in params
            // highlight (select) each day that has an auction on it
            foreach (System.Windows.Controls.Calendar calendar in calendarsToUpdate) {
                calendar.SelectedDates.Add(DateTime.Now);
                foreach (KeyValuePair<DateTime, List<Auction>> auction in auctions) {
                    Console.WriteLine(String.Join("\n\t", auctions[auction.Key]));
                    calendar.SelectedDates.Add(auction.Key);
                }
            }
        }

        private Dictionary<DateTime, List<Auction>> ConvertListToDict(List<Auction> auctionList) {
            Dictionary<DateTime, List<Auction>> toReturn = new Dictionary<DateTime, List<Auction>>();
            foreach (var auction in auctionList) {
                // if it already has the key append to the list
                if (toReturn.ContainsKey(auction.StartTime.Date)) {
                    toReturn[auction.StartTime.Date].Add(auction);
                }
                else {// otherwise create a list with the current auction
                    List<Auction> newList = new List<Auction> {auction};
                    toReturn.Add(auction.StartTime.Date, newList);
                }
            }

            return toReturn;
        }

        // sets the initial date to today
        private void SetCalendarDates() {
            DateTime date = DateTime.Now;

            CalendarSingleMonth.DisplayDate = date;
            CalendarThreeMonthFirst.DisplayDate = date.AddMonths(-1);
            CalendarThreeMonthSecond.DisplayDate = date;
            CalendarThreeMonthThird.DisplayDate = date.AddMonths(1);

        }


        // switches the 3 calendars whenever one of them change
        // remove the handler and add them back so that it doesn't recurse
        private void OnDisplayDateChanged(object sender, CalendarDateChangedEventArgs calendarDateChangedEventArgs) {
            if (Equals(sender, CalendarThreeMonthFirst)) {
                CalendarThreeMonthSecond.DisplayDateChanged -= OnDisplayDateChanged;
                CalendarThreeMonthThird.DisplayDateChanged -= OnDisplayDateChanged;

                CalendarThreeMonthSecond.DisplayDate = CalendarThreeMonthFirst.DisplayDate.AddMonths(1);
                CalendarThreeMonthThird.DisplayDate = CalendarThreeMonthFirst.DisplayDate.AddMonths(2);

                CalendarThreeMonthSecond.DisplayDateChanged += OnDisplayDateChanged;
                CalendarThreeMonthThird.DisplayDateChanged += OnDisplayDateChanged;

            }
            else if (Equals(sender, CalendarThreeMonthSecond)) {
                CalendarThreeMonthFirst.DisplayDateChanged -= OnDisplayDateChanged;
                CalendarThreeMonthThird.DisplayDateChanged -= OnDisplayDateChanged;

                CalendarThreeMonthFirst.DisplayDate = CalendarThreeMonthSecond.DisplayDate.AddMonths(-1);
                CalendarThreeMonthThird.DisplayDate = CalendarThreeMonthSecond.DisplayDate.AddMonths(1);


                CalendarThreeMonthFirst.DisplayDateChanged += OnDisplayDateChanged;
                CalendarThreeMonthThird.DisplayDateChanged += OnDisplayDateChanged;
            }
            else if (Equals(sender, CalendarThreeMonthThird)) {
                CalendarThreeMonthFirst.DisplayDateChanged -= OnDisplayDateChanged;
                CalendarThreeMonthSecond.DisplayDateChanged -= OnDisplayDateChanged;

                CalendarThreeMonthFirst.DisplayDate = CalendarThreeMonthThird.DisplayDate.AddMonths(-2);
                CalendarThreeMonthSecond.DisplayDate = CalendarThreeMonthThird.DisplayDate.AddMonths(-1);

                CalendarThreeMonthFirst.DisplayDateChanged += OnDisplayDateChanged;
                CalendarThreeMonthSecond.DisplayDateChanged += OnDisplayDateChanged;
            }
        }


        private void OnSelectedDatesChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs) {
            // Get the calendar
            System.Windows.Controls.Calendar calendarSent = sender as System.Windows.Controls.Calendar;
            DateTime selected;
            // had issues with calendarSent.Date.Value
	        DateTime.TryParse(calendarSent.ToString(), out selected);
            // remove the one they just selected
            calendarSent.SelectedDates.Remove(selected);
            calendarSent.SelectedDatesChanged -= OnSelectedDatesChanged;
            // readd the auctions
            AddAuctionsToCalendars(calendarSent);
            calendarSent.SelectedDatesChanged += OnSelectedDatesChanged;

            // if they clicked a day that has an auction display the dialog
            if (auctions.ContainsKey(selected.Date))
            {
                ListBoxDialog.ItemsSource = auctions[selected];
                CalendarDialogBox.IsOpen = true;

                CalendarDialogBox.ShowDialog(null);

            }
        }

        // allows the scrollViewer to scroll
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e) {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        // get the auction from the listbox and then navigate
        private void ListBoxDialog_OnMouseUp(object sender, MouseButtonEventArgs e) {
            Auction selected = ListBoxDialog.SelectedValue as Auction;

            // TODO Navigate to the proper page, US 39 says to view inventory after clicking
            (Window.GetWindow(this) as MainWindow).MainContent.NavigationService.Navigate(new AuctionDetails(selected));

        }
    }
}
