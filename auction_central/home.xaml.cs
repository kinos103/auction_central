using System;
using System.Windows;
using System.Windows.Controls;

namespace auction_central
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : Page
    {
        public home()
        {
            InitializeComponent();
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var black = (System.Windows.Media.Brush)converter.ConvertFromString("#000000");
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
            tb.Foreground = black;
        }
	}
}
