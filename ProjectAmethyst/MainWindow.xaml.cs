﻿using System;
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
using System.Windows.Shapes;

namespace ProjectAmethyst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MainPage mainPage = new MainPage();
        private GroupEditor groupEditor;
        private SettingsEditor settingsEditor;

        public MainWindow()
        {

            AmethystCore.LoadChampions();

            InitializeComponent();

            Main.Content = mainPage;
        }

        private void menuMain_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = mainPage;
        }

        private void menuGroups_Click(object sender, RoutedEventArgs e)
        {
            if (groupEditor == null)
            {
                groupEditor = new GroupEditor();
            }
            Main.Content = groupEditor;
        }

        private void menuSettings_Click(object sender, RoutedEventArgs e)
        {
            if (settingsEditor == null)
            {
                settingsEditor = new SettingsEditor();
            }
            Main.Content = settingsEditor;
        }
    }
}
