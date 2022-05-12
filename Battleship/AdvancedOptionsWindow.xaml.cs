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

namespace Battleship
{
    /// <summary>
    /// Interaction logic for AdvancedOptionsWindow.xaml
    /// </summary>
    public partial class AdvancedOptionsWindow : Window
    {
        private AdvancedOptions advancedOptions;

        public AdvancedOptionsWindow(ref AdvancedOptions p_advancedOptions)
        {
            InitializeComponent();

            this.advancedOptions = p_advancedOptions;

            this.AddDefaultShipTypesToComboBox(ref this.AdjustableFleetSize1ComboBox);
            this.AddDefaultShipTypesToComboBox(ref this.AdjustableFleetSize2ComboBox);
            this.AddDefaultShipTypesToComboBox(ref this.AdjustableFleetSize3ComboBox);
            this.AddDefaultShipTypesToComboBox(ref this.AdjustableFleetSize4ComboBox);
            this.AddDefaultShipTypesToComboBox(ref this.AdjustableFleetSize5ComboBox);
            this.AddDefaultShipTypesToComboBox(ref this.AdjustableFleetSize6ComboBox);
            this.AddDefaultShipTypesToComboBox(ref this.AdjustableFleetSize7ComboBox);
        }

        private void AdvancedOptionsWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            switch (this.advancedOptions.FleetSize)
            {
                case 3:
                    this.AdjustableFleetSize3RadioButton.IsChecked = true;
                    break;
                case 5:
                    this.AdjustableFleetSize5RadioButton.IsChecked = true;
                    this.SetFleetSizeComboBoxDisability(true, true, true, true, true, false, false);
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

        private void AddDefaultShipTypesToComboBox(ref ComboBox comboBox)
        {
            comboBox.Items.Add(StatusCodes.ShipType.DESTROYER);
            comboBox.Items.Add(StatusCodes.ShipType.SUBMARINE);
            comboBox.Items.Add(StatusCodes.ShipType.CRUISER);
            comboBox.Items.Add(StatusCodes.ShipType.BATTLESHIP);
            comboBox.Items.Add(StatusCodes.ShipType.CARRIER);
        }

        private void SetFleetSizeComboBoxDisability(bool ship1, bool ship2, bool ship3, bool ship4, bool ship5, bool ship6, bool ship7)
        {
            // Set the Default Values for Adjustable Fleet Size

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
