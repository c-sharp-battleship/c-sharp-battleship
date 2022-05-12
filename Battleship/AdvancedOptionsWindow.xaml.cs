//-----------------------------------------------------------------------
// <copyright file="AdvancedOptionsWindow.xaml.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for AdvancedOptionsWindow.xaml.
    /// </summary>
    public partial class AdvancedOptionsWindow : Window
    {
        /// <summary>
        /// The advanced options.
        /// </summary>
        private AdvancedOptions advancedOptions;

        public AdvancedOptionsWindow(ref AdvancedOptions p_advancedOptions)
        {
            this.InitializeComponent();

            this.advancedOptions = p_advancedOptions;
        }

        private void SetFleetSizeComboBoxDisability(bool ship1, bool ship2, bool ship3, bool ship4, bool ship5, bool ship6, bool ship7)
        {
            this.AdjustableFleetSize1ComboBox.IsEnabled = ship1;
            this.AdjustableFleetSize2ComboBox.IsEnabled = ship2;
            this.AdjustableFleetSize3ComboBox.IsEnabled = ship3;
            this.AdjustableFleetSize4ComboBox.IsEnabled = ship4;
            this.AdjustableFleetSize5ComboBox.IsEnabled = ship5;
            this.AdjustableFleetSize6ComboBox.IsEnabled = ship6;
            this.AdjustableFleetSize7ComboBox.IsEnabled = ship7;
        }

        private void AdjustableFleetSize3RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.FleetSize = 3;

            this.SetFleetSizeComboBoxDisability(true, true, true, false, false, false, false);
        }

        private void AdjustableFleetSize5RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.FleetSize = 5;

            this.SetFleetSizeComboBoxDisability(true, true, true, true, true, false, false);
        }

        private void AdjustableFleetSize7RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.FleetSize = 7;

            this.SetFleetSizeComboBoxDisability(true, true, true, true, true, true, true);
        }

        private void AdjustableFleetSize1ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AdjustableFleetSize2ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AdjustableFleetSize3ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AdjustableFleetSize4ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AdjustableFleetSize5ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AdjustableFleetSize6ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AdjustableFleetSize7ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AdjustableGridSize8RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.GridSize = 8;
        }

        private void AdjustableGridSize10RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.GridSize = 10;
        }

        private void AdjustableGridSize12RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.GridSize = 12;
        }

        private void MultipleAttacksPerSuccessfulAttackCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.PlayerCanAttackAgain = true;
        }

        private void MultipleAttacksPerTurnPerShip_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.EachShipGetsAShot = true;
        }

        private void EachPlayerCanAttackLargeGridSpaceCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.PlayerGetsABombMove = true;

            if(this.EachPlayerCanAttackLargeGridSpaceCheckBox.IsChecked == true)
            {
                this.EachPlayerCanAttackLargeGridSpaceComboBox.IsEnabled = true;
            }
            else
            {
                this.EachPlayerCanAttackLargeGridSpaceComboBox.IsEnabled = false;
            }
        }

        private void EachPlayerCanAttackLargeGridSpaceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DefaultOptionsButton_Click(object sender, RoutedEventArgs e)
        {
            this.AdjustableFleetSize5RadioButton.IsChecked = true;
            this.AdjustableGridSize10RadioButton.IsChecked = true;
            this.MultipleAttacksPerSuccessfulAttackCheckBox.IsChecked = false;
            this.MultipleAttacksPerTurnPerShip.IsChecked = false;
            this.EachPlayerCanAttackLargeGridSpaceCheckBox.IsChecked = false;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
