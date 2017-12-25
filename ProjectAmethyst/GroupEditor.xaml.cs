using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjectAmethyst
{
    /// <summary>
    /// Interaction logic for GroupEditor.xaml
    /// </summary>
    public partial class GroupEditor : Page
    {
        public GroupEditor()
        {

            InitializeComponent();

            List<Champion> champs = AmethystCore.GetChampList();

            foreach(Champion champ in champs)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = champ;
                if (champList.SelectedIndex == -1) item.IsSelected = true;
                champList.Items.Add(item);
            }

            foreach(ChampionGroup group in ChampionGroup.groups)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = group;
                if (groupList.SelectedIndex == -1) item.IsSelected = true;
                groupList.Items.Add(item);
            }

        }

        private void addChamp_Click(object sender, RoutedEventArgs e)
        {
            Champion champ = getSelectedChampion();
            if (champListBox.Items.Contains(champ)) { return; }

            champListBox.Items.Add(champ);

            ChampionGroup champGroup = getSelectedChampionGroup();
            champGroup.AddChamp(champ);
        }

        private void removeChamp_Click(object sender, RoutedEventArgs e)
        {
            Champion champ = champListBox.SelectedValue as Champion;
            if (!champListBox.Items.Contains(champ)) { return;  }

            champListBox.Items.Remove(champ);

            ChampionGroup champGroup = getSelectedChampionGroup();
            champGroup.RemoveChamp(champ);
        }

        private void groupList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (groupList.SelectedIndex == -1) return;
            champListBox.Items.Clear();
            foreach(Champion champ in getSelectedChampionGroup().getChamps())
            {
                champListBox.Items.Add(champ);
            }
        }

        private Champion getSelectedChampion()
        {
            return ((ComboBoxItem)champList.SelectedValue).Content as Champion;
        }

        private ChampionGroup getSelectedChampionGroup()
        {
            return ((ComboBoxItem)groupList.SelectedValue).Content as ChampionGroup;
        }

        private void addGroup_Click(object sender, RoutedEventArgs e)
        {

            string text = groupName.Text;

            if ((text == "Group Name") || ChampionGroup.Find(text) != null) return;

            ChampionGroup group = new ChampionGroup(text);
            ChampionGroup.groups.Add(group);

            ComboBoxItem item = new ComboBoxItem();
            item.Content = group;
            if (groupList.SelectedIndex == -1) item.IsSelected = true;
            groupList.Items.Add(item);
        }

        private void removeGroup_Click(object sender, RoutedEventArgs e)
        {
            if (groupList.SelectedItem == null) return;
            ChampionGroup group = getSelectedChampionGroup();

            groupList.Items.Remove((ComboBoxItem)groupList.SelectedItem);

            if (groupList.Items.Count > 0) {
                ((ComboBoxItem)groupList.Items[0]).IsSelected = true;
            }

            ChampionGroup.groups.Remove(group);

        }

        private void champList_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Champion champ = getSelectedChampion();
                if (champListBox.Items.Contains(champ)) { return; }

                champListBox.Items.Add(champ);

                ChampionGroup champGroup = getSelectedChampionGroup();
                champGroup.AddChamp(champ);
            };
        }
    }
}
