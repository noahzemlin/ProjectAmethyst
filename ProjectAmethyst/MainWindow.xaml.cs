using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProjectAmethyst
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool invisible = true;

        public MainWindow()
        {

            AmethystCore.LoadChampions();

            InitializeComponent();


        }


        private void genChamp_Click(object sender, RoutedEventArgs e)
        {
            AmethystCore.GetChampion();

            ((Label)this.FindName("champName")).Content = AmethystCore.currentChampion;

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("http://ddragon.leagueoflegends.com/cdn/6.24.1/img/champion/" + AmethystCore.currentChampion + ".png");
            logo.EndInit();

            ((Image)this.FindName("champImage")).Source = logo;

            if (invisible)
            {
                invisible = false;
                ((Grid)this.FindName("champGrid")).Visibility = Visibility.Visible;
            }
        }

        private void buttonLAL_Click(object sender, RoutedEventArgs e)
        {
            openURL("https://lolalytics.com/champion/" + AmethystCore.currentChampion + "/");
        }

        private void buttonOPGG_Click(object sender, RoutedEventArgs e)
        {
            openURL("https://op.gg/champion/" + AmethystCore.currentChampion + "/");
        }

        private void buttonCGG_Click(object sender, RoutedEventArgs e)
        {
            openURL("http://champion.gg/champion/" + AmethystCore.currentChampion + "/");
        }

        private void openURL(String url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch { }
        }

    }
}
