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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void addItemButton_Click(object sender, RoutedEventArgs e)
        {
            string itemName = this.itemName.Text;
            int auctionID = Int32.Parse(this.auctionID.Text);
            int itemQuantity = Int32.Parse(this.itemQuantity.Text);

            //originalprice = startBid
            int startBid = Int32.Parse(this.startBid.Text);

            //should donorID be a string?
            string donor= this.donor.Text;

            int height = Int32.Parse(this.height.Text);
            int length = Int32.Parse(this.length.Text);
            int width = Int32.Parse(this.width.Text);

            
            var itemunit = (ComboBoxItem)ComboBox_units.SelectedItem;
            if (Equals(itemunit, meters_val))
            {
                itemunit = meters_val;

            }
            else if (Equals(itemunit, feet_val))
            {
                itemunit = feet_val;
            }
            else if (Equals(itemunit, cm_val))
            {
                itemunit = cm_val;
            }
            else
            {
                MessageBox.Show("Please Select a unit Type");

            }

            //string size = this.size.Text; will be is small ComboBox_small_item
            var issmall = (ComboBoxItem)ComboBox_small_item.SelectedItem;
            //dont allow question to be chosen in combobox
            if (Equals(issmall, yes))
            {
                issmall = yes;
            }
            else if (Equals(issmall, no))
            {
                issmall= no;
            }
            else
            {
                MessageBox.Show("Is this a small item?");

            }

            string storageLocation = this.storageLocation.Text;

            //int condition = Int32.Parse(this.condition.Text); will be ComboBox_condition 
            var condition = (ComboBoxItem)ComboBox_condition.SelectedItem;
            //don't allow Item_Condition to be chosen in combobox
            if (Equals(condition, New))
            {
                condition = New;
            }
            else if (Equals(issmall, Used))
            {
                condition = Used;
            }
            else
            {
                MessageBox.Show("What is the condition of this item?");

            }

        }

    }
}
