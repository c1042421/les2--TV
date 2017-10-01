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
        List<Warmwaterkoker> waterkokers;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MakeTVSAndSetChecked();
            MakeWaterKokersAndSetList();
        }

        private void MakeTVSAndSetChecked()
        {
            sony = new TV("Sony", "KDL-40RD450", 50, 40, "sony.png");
            samsung = new TV("Samsung", "UE55KS7000", 100, 55, "samsung.png");

            rdbSony.IsChecked = true;
        }

        private void MakeWaterKokersAndSetList()
        {
            waterkokers = new List<Warmwaterkoker>();

            waterkokers.Add(new Warmwaterkoker("PHILIPS", "HD4646/70", "images/philips1.jpg", (decimal)1.5));
            waterkokers.Add(new Warmwaterkoker("EMERIO", "WK-110874", "images/waterkoker2.png", (decimal)1.7));

            cbWaterKokers.DisplayMemberPath = "Type";
            cbWaterKokers.ItemsSource = waterkokers;
        }

        private void RdbSony_Checked(object sender, RoutedEventArgs e)
        {
            UpdateViewWith(sony);
        }

        private void RdbSamsung_Checked(object sender, RoutedEventArgs e)
        {
            UpdateViewWith(samsung);
        }

        private void UpdateViewWith(ElektronischToestel et)
        {
            lblInfo.Content = et.ToString();
            imgTV.Source = MakeBitMapImageFor(et.Afbeelding);
            cbPower.IsChecked = et.Power;

            if (et is TV)
            {
                TV tv = (TV)et;
                txtKanaal.Text = tv.Kanaal.ToString();
                txtVolume.Text = tv.Volume.ToString();
            }
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

        private void cbWaterKokers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Warmwaterkoker koker = (Warmwaterkoker)cb.SelectedItem;
            UpdateViewWith(koker);
        }

        private void cbPower_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            bool cbChecked = cb.IsChecked ?? false;
            ElektronischToestel toestel;

            if (tbiTV.IsSelected)
            {
                bool samsungChecked = rdbSamsung.IsChecked ?? false;

                toestel = samsungChecked ? samsung : sony;
            }
            else
            {
                toestel = (Warmwaterkoker)cbWaterKokers.SelectedItem;
            }

            toestel.Power = cbChecked;
        }
    }
}
