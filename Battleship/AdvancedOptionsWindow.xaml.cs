//-----------------------------------------------------------------------
// <copyright file="AdvancedOptionsWindow.xaml.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for AdvancedOptionsWindow.xaml.
    /// </summary>
    public partial class AdvancedOptionsWindow : Window
    {
        /// <summary>
        /// The advanced options object to be passed by reference.
        /// </summary>
        private AdvancedOptions advancedOptions;

        /// <summary>
        /// The ship loading window.
        /// </summary>
        private Ship_Loading shipLoading;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvancedOptionsWindow"/> class.
        /// </summary>
        /// <param name="p_advancedOptions">The advancedOptions instance to be passed by reference and assigned as a class-member object.</param>
        public AdvancedOptionsWindow(ref AdvancedOptions p_advancedOptions)
        {
            this.InitializeComponent();

            this.advancedOptions = p_advancedOptions;
            this.shipLoading = new Ship_Loading(ref p_advancedOptions);
        }

        /// <summary>
        /// Load event for the <see cref="AdvancedOptionsWindow"/> class.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        /// <exception cref="Exception">Thrown if the <see cref="advancedOptions"/>'s FleetSize is invalid.</exception>
        private void AdvancedOptionsWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            switch (this.advancedOptions.GridSize)
            {
                case 8:
                    this.AdjustableGridSize8RadioButton.IsChecked = true;
                    break;
                case 10:
                    this.AdjustableGridSize10RadioButton.IsChecked = true;
                    break;
                case 12:
                    this.AdjustableGridSize12RadioButton.IsChecked = true;
                    break;
                default:
                    throw new Exception();
                    break;
            }
        }

        /// <summary>
        /// Checked event for the <see cref="AdjustableGridSize8RadioButton"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AdjustableGridSize8RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.GridSize = 8;
        }

        /// <summary>
        /// Checked event for the <see cref="AdjustableGridSize10RadioButton"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AdjustableGridSize10RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.GridSize = 10;
        }

        /// <summary>
        /// Checked event for the <see cref="AdjustableGridSize12RadioButton"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AdjustableGridSize12RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.GridSize = 12;
        }

        /// <summary>
        /// Checked event for the <see cref="MultipleAttacksPerSuccessfulAttackCheckBox"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void MultipleAttacksPerSuccessfulAttackCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.PlayerCanAttackAgain = true;
        }

        /// <summary>
        /// Checked event for the <see cref="MultipleAttacksPerTurnPerShip"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void MultipleAttacksPerTurnPerShip_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.EachShipGetsAShot = true;
        }

        /// <summary>
        /// Checked event for the <see cref="EachPlayerCanAttackLargeGridSpaceCheckBox"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void EachPlayerCanAttackLargeGridSpaceCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.PlayerGetsABombMove = true;

            if (this.EachPlayerCanAttackLargeGridSpaceCheckBox.IsChecked == true)
            {
                this.EachPlayerCanAttackLargeGridSpaceComboBox.IsEnabled = true;
            }
            else
            {
                this.EachPlayerCanAttackLargeGridSpaceComboBox.IsEnabled = false;
            }
        }

        /// <summary>
        /// SelectionChanged event for the <see cref="EachPlayerCanAttackLargeGridSpaceComboBox"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void EachPlayerCanAttackLargeGridSpaceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Implement EachPlayerCanAttackLargeGridSpaceComboBox_SelectionChanged
        }

        /// <summary>
        /// Click event for the <see cref="DefaultOptionsButton"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void DefaultOptionsButton_Click(object sender, RoutedEventArgs e)
        {
            this.AdjustableGridSize10RadioButton.IsChecked = true;
            this.MultipleAttacksPerSuccessfulAttackCheckBox.IsChecked = false;
            this.MultipleAttacksPerTurnPerShip.IsChecked = false;
            this.EachPlayerCanAttackLargeGridSpaceCheckBox.IsChecked = false;
        }

        /// <summary>
        /// Click event for the <see cref="ExitButton"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CustomFleetButton_Click(object sender, RoutedEventArgs e)
        {
            this.shipLoading.Show();
        }
    }
}
