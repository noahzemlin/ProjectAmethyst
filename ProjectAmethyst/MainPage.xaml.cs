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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        private bool invisible = true;

        public MainPage()
        {
            InitializeComponent();

            ((Grid)this.FindName("champGrid")).Visibility = Visibility.Hidden;
        }


        private void genChamp_Click(object sender, RoutedEventArgs e)
        {
            string currChampion = AmethystCore.GetNewChampion();
            string version = AmethystCore.GetVersion();

            ((Label)this.FindName("champName")).Content = AmethystCore.GetName(currChampion);

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("http://ddragon.leagueoflegends.com/cdn/" + version + "/img/champion/" + currChampion + ".png");
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
            openURL("https://lolalytics.com/champion/" + AmethystCore.GetCurrentChampion() + "/");
        }

        private void buttonOPGG_Click(object sender, RoutedEventArgs e)
        {
            openURL("https://op.gg/champion/" + AmethystCore.GetCurrentChampion() + "/");
        }

        private void buttonCGG_Click(object sender, RoutedEventArgs e)
        {
            openURL("http://champion.gg/champion/" + AmethystCore.GetCurrentChampion() + "/");
        }

        private void openURL(String url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch { }
        }

        private void saveSettings(object sender, RoutedEventArgs e)
        {
            Settings.saveSettings();
        }

        private void poolList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (poolList.SelectedValue == null) return;
            if(poolList.SelectedValue.ToString() == "All Champions") {
                ChampionGroup.selected = null;
            } else
            {
                ChampionGroup.selected = (ChampionGroup)poolList.SelectedValue;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            poolList.Items.Clear();
            poolList.Items.Add("All Champions");
            foreach (ChampionGroup group in ChampionGroup.groups)
            {
                poolList.Items.Add(group);
            }
        }
    }
}
