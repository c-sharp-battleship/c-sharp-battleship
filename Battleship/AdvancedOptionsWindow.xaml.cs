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

        private void AdjustableFleetSize3RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.FleetSize = 3;
        }

        private void AdjustableFleetSize5RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.FleetSize = 5;
        }

        private void AdjustableFleetSize7RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.FleetSize = 7;
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

        }

        private void AdjustableGridSize10RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void AdjustableGridSize12RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void MultipleAttacksPerSuccessfulAttackCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void MultipleAttacksPerTurnPerShip_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void EachPlayerCanAttackLargeGridSpaceCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void EachPlayerCanAttackLargeGridSpaceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DefaultOptionsButton_Click(object sender, RoutedEventArgs e)
        {
            // Set the Default Values for Adjustable Fleet Size

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
