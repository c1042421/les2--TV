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

namespace oefTV

{
    public partial class MainWindow : Window
    {
        TV sony, samsung;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sony = new TV("Sony", "KDL-40RD450", 50, 40, "sony.png");
            samsung = new TV("Samsung", "UE55KS7000", 100, 55, "samsung.png");
        }

        private void RdbSony_Checked(object sender, RoutedEventArgs e)
        {
            UpdateViewWith(sony);
        }

        private void RdbSamsung_Checked(object sender, RoutedEventArgs e)
        {
            UpdateViewWith(samsung);
        }
        private void UpdateViewWith(TV tv)
        {
            lblInfo.Content = tv.ToString();
            txtKanaal.Text = tv.Kanaal.ToString();
            txtVolume.Text = tv.Volume.ToString();
            imgTV.Source = MakeBitMapImageFor(tv.Afbeelding);
            cbPower.IsChecked = tv.Power;
        }

        private BitmapImage MakeBitMapImageFor(string url)
        {
            Uri uri = new Uri(@"images\" + url, UriKind.Relative);
            return new BitmapImage(uri);
        }

        private void txtKanaal_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            bool samsungChecked = rdbSamsung.IsChecked ?? false;
            int kanaal;

            if (int.TryParse(txtKanaal.Text, out kanaal))
            {
                TV tv = samsungChecked ? samsung : sony;
                tv.Kanaal = kanaal;
            }
        }

        private void txtVolume_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            bool samsungChecked = rdbSamsung.IsChecked ?? false;
            int volume;

            if (int.TryParse(txtVolume.Text, out volume))
            {
                TV tv = samsungChecked ? samsung : sony;
                tv.Volume = volume;
            }
        }

        private void CbPower_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            bool samsungChecked = rdbSamsung.IsChecked ?? false;
            bool cbChecked = cb.IsChecked ?? false;

            TV tv = samsungChecked ? samsung : sony;
            tv.Power = cbChecked;
        }
    }
}
