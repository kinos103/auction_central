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

            // TODO get list of auctions from dbWrap instead of temp data
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

            List<Auction> tempAuctionList = dbWrap.AuctionObjList();




            auctions = ConvertListToDict(tempAuctionList);

            AddAuctionsToCalendars(CalendarSingleMonth, CalendarThreeMonthFirst, CalendarThreeMonthSecond, CalendarThreeMonthThird);

            CalendarSingleMonth.SelectedDatesChanged += OnDisplayDateChange;
            CalendarThreeMonthFirst.SelectedDatesChanged += OnDisplayDateChange;
            CalendarThreeMonthSecond.SelectedDatesChanged += OnDisplayDateChange;
            CalendarThreeMonthThird.SelectedDatesChanged += OnDisplayDateChange;

            CalendarSingleMonth.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;
            CalendarThreeMonthFirst.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;
            CalendarThreeMonthSecond.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;
            CalendarThreeMonthThird.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;


        }

        private void AddAuctionsToCalendars(params System.Windows.Controls.Calendar[] calendarsToUpdate) {

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
                if (toReturn.ContainsKey(auction.StartTime.Date)) {
                    toReturn[auction.StartTime.Date].Add(auction);
                }
                else {
                    List<Auction> newList = new List<Auction> {auction};
                    toReturn.Add(auction.StartTime.Date, newList);
                }
            }

            return toReturn;
        }

        private void SetCalendarDates() {
            DateTime date = DateTime.Now;

            CalendarSingleMonth.DisplayDate = date;
            CalendarThreeMonthFirst.DisplayDate = date.AddMonths(-1);
            CalendarThreeMonthSecond.DisplayDate = date;
            CalendarThreeMonthThird.DisplayDate = date.AddMonths(1);

        }



        private void CalendarThreeMonthFirst_OnSelectedDatesChanged(object sender, CalendarDateChangedEventArgs calendarDateChangedEventArgs) {
//            AddAuctionsToCalendars(CalendarSingleMonth,CalendarThreeMonthFirst, CalendarThreeMonthSecond, CalendarThreeMonthThird);
            if (Equals(sender, CalendarThreeMonthFirst)) {
                CalendarThreeMonthSecond.DisplayDateChanged -= CalendarThreeMonthFirst_OnSelectedDatesChanged;
                CalendarThreeMonthThird.DisplayDateChanged -= CalendarThreeMonthFirst_OnSelectedDatesChanged;

                CalendarThreeMonthSecond.DisplayDate = CalendarThreeMonthFirst.DisplayDate.AddMonths(1);
                CalendarThreeMonthThird.DisplayDate = CalendarThreeMonthFirst.DisplayDate.AddMonths(2);

                CalendarThreeMonthSecond.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;
                CalendarThreeMonthThird.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;

            }
            else if (Equals(sender, CalendarThreeMonthSecond)) {
                CalendarThreeMonthFirst.DisplayDateChanged -= CalendarThreeMonthFirst_OnSelectedDatesChanged;
                CalendarThreeMonthThird.DisplayDateChanged -= CalendarThreeMonthFirst_OnSelectedDatesChanged;

                CalendarThreeMonthFirst.DisplayDate = CalendarThreeMonthSecond.DisplayDate.AddMonths(-1);
                CalendarThreeMonthThird.DisplayDate = CalendarThreeMonthSecond.DisplayDate.AddMonths(1);


                CalendarThreeMonthFirst.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;
                CalendarThreeMonthThird.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;
            }
            else if (Equals(sender, CalendarThreeMonthThird)) {
                CalendarThreeMonthFirst.DisplayDateChanged -= CalendarThreeMonthFirst_OnSelectedDatesChanged;
                CalendarThreeMonthSecond.DisplayDateChanged -= CalendarThreeMonthFirst_OnSelectedDatesChanged;

                CalendarThreeMonthFirst.DisplayDate = CalendarThreeMonthThird.DisplayDate.AddMonths(-2);
                CalendarThreeMonthSecond.DisplayDate = CalendarThreeMonthThird.DisplayDate.AddMonths(-1);

                CalendarThreeMonthFirst.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;
                CalendarThreeMonthSecond.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;
            }
        }

        private void OnDisplayDateChange(object sender, SelectionChangedEventArgs selectionChangedEventArgs) {
            System.Windows.Controls.Calendar calendarSent = sender as System.Windows.Controls.Calendar;
            Console.WriteLine(calendarSent);
//            DateTime selected = calendarSent.SelectedDate.Value;
            DateTime selected;
	        DateTime.TryParse(calendarSent.ToString(), out selected);
            calendarSent.SelectedDates.Remove(selected);
            calendarSent.SelectedDatesChanged -= OnDisplayDateChange;
            AddAuctionsToCalendars(calendarSent);
            calendarSent.SelectedDatesChanged += OnDisplayDateChange;

            if (auctions.ContainsKey(selected.Date))
            {
                ListBoxDialog.ItemsSource = auctions[selected];
                CalendarDialogBox.IsOpen = true;

                CalendarDialogBox.ShowDialog(null);

            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e) {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void ListBoxDialog_OnMouseUp(object sender, MouseButtonEventArgs e) {
            Auction selected = ListBoxDialog.SelectedValue as Auction;

            // TODO Navigate to the proper page, US 39 says to view inventory after clicking
            (Window.GetWindow(this) as MainWindow).MainContent.NavigationService.Navigate(new AuctionDetails(selected));

        }
    }
}
