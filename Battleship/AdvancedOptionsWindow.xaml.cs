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
        /// Initializes a new instance of the <see cref="AdvancedOptionsWindow"/> class.
        /// </summary>
        /// <param name="p_advancedOptions">The advancedOptions instance to be passed by reference and assigned as a class-member object.</param>
        public AdvancedOptionsWindow(ref AdvancedOptions p_advancedOptions)
        {
            this.InitializeComponent();

            this.advancedOptions = p_advancedOptions;
        }

        /// <summary>
        /// Load event for the <see cref="AdvancedOptionsWindow"/> class.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        /// <exception cref="Exception">Thrown if the <see cref="advancedOptions"/>'s FleetSize is invalid.</exception>
        private void AdvancedOptionsWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            switch (this.advancedOptions.FleetSize)
            {
                case 3:
                    this.AdjustableFleetSize3RadioButton.IsChecked = true;
                    break;
                case 5:
                    this.AdjustableFleetSize5RadioButton.IsChecked = true;
                    break;
                case 7:
                    this.AdjustableFleetSize5RadioButton.IsChecked = true;
                    break;
                default:
                    throw new Exception();
                    break;
            }

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
        /// Method to set the <see cref="ComboBox"/> IsEnabled property.
        /// </summary>
        /// <param name="ship1">Whether or not the first ComboBox should be enabled.</param>
        /// <param name="ship2">Whether or not the second ComboBox should be enabled.</param>
        /// <param name="ship3">Whether or not the third ComboBox should be enabled.</param>
        /// <param name="ship4">Whether or not the fourth ComboBox should be enabled.</param>
        /// <param name="ship5">Whether or not the fifth ComboBox should be enabled.</param>
        /// <param name="ship6">Whether or not the sixth ComboBox should be enabled.</param>
        /// <param name="ship7">Whether or not the seventh ComboBox should be enabled.</param>
        private void SetFleetSizeComboBoxDisability(bool ship1, bool ship2, bool ship3, bool ship4, bool ship5, bool ship6, bool ship7)
        {
            // Set the Default Values for Adjustable Fleet Size
            this.AdjustableFleetSize1ComboBox.IsEnabled = ship1;
            this.AdjustableFleetSize2ComboBox.IsEnabled = ship2;
            this.AdjustableFleetSize3ComboBox.IsEnabled = ship3;
            this.AdjustableFleetSize4ComboBox.IsEnabled = ship4;
            this.AdjustableFleetSize5ComboBox.IsEnabled = ship5;
            this.AdjustableFleetSize6ComboBox.IsEnabled = ship6;
            this.AdjustableFleetSize7ComboBox.IsEnabled = ship7;
        }

        /// <summary>
        /// Checked event for the <see cref="AdjustableFleetSize3RadioButton"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AdjustableFleetSize3RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.FleetSize = 3;

            this.SetFleetSizeComboBoxDisability(true, true, true, false, false, false, false);
        }

        /// <summary>
        /// Checked event for the <see cref="AdjustableFleetSize5RadioButton"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AdjustableFleetSize5RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.FleetSize = 5;

            this.SetFleetSizeComboBoxDisability(true, true, true, true, true, false, false);
        }

        /// <summary>
        /// Checked event for the <see cref="AdjustableFleetSize7RadioButton"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AdjustableFleetSize7RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.advancedOptions.FleetSize = 7;

            this.SetFleetSizeComboBoxDisability(true, true, true, true, true, true, true);
        }

        /// <summary>
        /// SelectionChanged event for the <see cref="AdjustableFleetSize1ComboBox"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AdjustableFleetSize1ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Implement AdjustableFleetSize1ComboBox_SelectionChanged
        }

        /// <summary>
        /// SelectionChanged event for the <see cref="AdjustableFleetSize2ComboBox"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AdjustableFleetSize2ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Implement AdjustableFleetSize2ComboBox_SelectionChanged
        }

        /// <summary>
        /// SelectionChanged event for the <see cref="AdjustableFleetSize3ComboBox"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AdjustableFleetSize3ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Implement AdjustableFleetSize3ComboBox_SelectionChanged
        }

        /// <summary>
        /// SelectionChanged event for the <see cref="AdjustableFleetSize4ComboBox"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AdjustableFleetSize4ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Implement AdjustableFleetSize4ComboBox_SelectionChanged
        }

        /// <summary>
        /// SelectionChanged event for the <see cref="AdjustableFleetSize5ComboBox"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AdjustableFleetSize5ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Implement AdjustableFleetSize5ComboBox_SelectionChanged
        }

        /// <summary>
        /// SelectionChanged event for the <see cref="AdjustableFleetSize6ComboBox"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AdjustableFleetSize6ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Implement AdjustableFleetSize6ComboBox_SelectionChanged
        }

        /// <summary>
        /// SelectionChanged event for the <see cref="AdjustableFleetSize7ComboBox"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AdjustableFleetSize7ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Implement AdjustableFleetSize7ComboBox_SelectionChanged
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
            this.AdjustableFleetSize5RadioButton.IsChecked = true;
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
    }
}
