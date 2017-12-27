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

namespace ProjectAmethyst
{
    /// <summary>
    /// Interaction logic for SettingsEditor.xaml
    /// </summary>
    public partial class SettingsEditor : Page
    {
        public static string _version;
        public SettingsEditor()
        {
            InitializeComponent();

            //Get app version
            Console.WriteLine("Retrieving project version number");
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            _version = fvi.FileVersion;
            Console.WriteLine("Done.\nRetrieving Settings");

            if (FileHandle._settings == null)
            {
                FileHandle.readSettings();
            }

            updateSettings();
            Console.WriteLine("Done.");
        }

        public void updateSettings()
        {
            //Update league version text box
            ((Label)this.FindName("leagueVersion")).Content = AmethystCore.GetVersion();
            //Update app version text box
            ((Label)this.FindName("appVersion")).Content = _version;
            //Update startWithWindows toggle thing
            ((RadioButton)this.FindName("startToggle")).IsChecked = FileHandle._settings.startWithWindows;
        }

        private void toggleStartSetting(object sender, RoutedEventArgs e)
        {
            FileHandle._settings.startWithWindows = !(FileHandle._settings.startWithWindows);
        }

        private void saveSettings(object sender, RoutedEventArgs e)
        {
            FileHandle._settings.appVersion = _version;
            FileHandle._settings.leagueVersion = AmethystCore.GetVersion();

            FileHandle.writeSettings();
        }

        private void discardSettings(object sender, RoutedEventArgs e)
        {
            FileHandle.readSettings();
            updateSettings();
        }

        private void resetSettings(object sender, RoutedEventArgs e)
        {
            FileHandle._settings = FileHandle.getDefaultSettings();
            updateSettings();
        }
    }
}
