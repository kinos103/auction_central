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
    /// Interaction logic for Calendar.xaml
    /// </summary>
    /// 

    public partial class Calendar : Page
    {
        public Calendar()
        {
            InitializeComponent();
            SetCalendarDates();
        }

        private void SetCalendarDates() {
            DateTime date = DateTime.Now;

            CalendarSingleMonth.DisplayDate = date;
            CalendarThreeMonthFirst.DisplayDate = date;
            CalendarThreeMonthSecond.DisplayDate = date;
            CalendarThreeMonthThird.DisplayDate = date;

            CalendarSingleMonth.SelectedDate = date;
            CalendarThreeMonthFirst.SelectedDate = date.AddMonths(-1);
            CalendarThreeMonthSecond.SelectedDate = date;
            CalendarThreeMonthThird.SelectedDate = date.AddMonths(1);
        }



        private void CalendarThreeMonthFirst_OnSelectedDatesChanged(object sender, CalendarDateChangedEventArgs calendarDateChangedEventArgs) {
            if (Equals(sender, CalendarThreeMonthFirst)) {
                Console.WriteLine("First");
                CalendarThreeMonthSecond.DisplayDateChanged -= CalendarThreeMonthFirst_OnSelectedDatesChanged;
                CalendarThreeMonthThird.DisplayDateChanged -= CalendarThreeMonthFirst_OnSelectedDatesChanged;

                CalendarThreeMonthSecond.DisplayDate = CalendarThreeMonthFirst.DisplayDate.AddMonths(1);
                CalendarThreeMonthThird.DisplayDate = CalendarThreeMonthFirst.DisplayDate.AddMonths(2);

                CalendarThreeMonthSecond.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;
                CalendarThreeMonthThird.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;

            }
            else if (Equals(sender, CalendarThreeMonthSecond)) {
                Console.WriteLine("Second");
                CalendarThreeMonthFirst.DisplayDateChanged -= CalendarThreeMonthFirst_OnSelectedDatesChanged;
                CalendarThreeMonthThird.DisplayDateChanged -= CalendarThreeMonthFirst_OnSelectedDatesChanged;

                CalendarThreeMonthFirst.DisplayDate = CalendarThreeMonthSecond.DisplayDate.AddMonths(-1);
                CalendarThreeMonthThird.DisplayDate = CalendarThreeMonthSecond.DisplayDate.AddMonths(1);


                CalendarThreeMonthFirst.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;
                CalendarThreeMonthThird.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;
            }
            else if (Equals(sender, CalendarThreeMonthThird)) {
                Console.WriteLine("Third");
                CalendarThreeMonthFirst.DisplayDateChanged -= CalendarThreeMonthFirst_OnSelectedDatesChanged;
                CalendarThreeMonthSecond.DisplayDateChanged -= CalendarThreeMonthFirst_OnSelectedDatesChanged;

                CalendarThreeMonthFirst.DisplayDate = CalendarThreeMonthThird.DisplayDate.AddMonths(-2);
                CalendarThreeMonthSecond.DisplayDate = CalendarThreeMonthThird.DisplayDate.AddMonths(-1);

                CalendarThreeMonthFirst.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;
                CalendarThreeMonthSecond.DisplayDateChanged += CalendarThreeMonthFirst_OnSelectedDatesChanged;
            }
        }
    }
}
